using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections;
public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinValue;
    [SerializeField] private TextMeshProUGUI nonCoinValue;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private UI ui;
    private int coinAmount;

    private void Start()
    {
        FindObjectOfType<PlayerData>().OnCoinValueChanged.AddListener(ChangeCoinValueText);
        coinAmount = 0;
        FindObjectsOfType<Coin>().ToList().ForEach(c => coinAmount += c.CoinValue);
        ChangeCoinValueText(0);
    }

    private void ChangeCoinValueText(int value)
    {
        coinValue.text = "Зібрано: " + value;
        nonCoinValue.text = "Залишилось: " + (coinAmount - value);
        if (value >= coinAmount)
        {
            winText.text = "ПЕРЕМОГА!";
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Cursor.lockState = CursorLockMode.Confined;
        ui.Play("UI");
    }

}
