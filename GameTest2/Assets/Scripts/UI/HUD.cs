using UnityEngine;
using TMPro;
using System.Linq;
public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinValue;
    [SerializeField] private TextMeshProUGUI nonCoinValue;
    [SerializeField] private TextMeshProUGUI winText;
    private int coinAmount;

    private void Start() {
        FindObjectOfType<PlayerData>().OnCoinValueChanged.AddListener(ChangeCoinValueText);
        coinAmount = 0;
        FindObjectsOfType<Coin>().ToList().ForEach(c => coinAmount += c.CoinValue);
        ChangeCoinValueText(0);
    }

    private void ChangeCoinValueText(int value)
    {
        coinValue.text = "Зібрано: " + value;
        nonCoinValue.text = "Залишилось: " + (coinAmount - value);
        if(value >= coinAmount)
            winText.text = "ПЕРЕМОГА!";
    }

}
