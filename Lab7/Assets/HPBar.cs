using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Transform  lookTarget;
    [SerializeField] private Image barImage;

    private void Start()
    {
        lookTarget = FindObjectOfType<Camera>().transform;
        transform.parent.GetComponent<Enemy>().OnDamage.AddListener(ChangeBar);
    }

    void Update()
    {
        transform.LookAt(lookTarget);
    }

    public void ChangeBar(float value)
    {
        barImage.fillAmount = value;
    }
}
