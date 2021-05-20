using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour
{
    private int coinValue = 0;
    public IntEvent OnCoinValueChanged;
    public class IntEvent : UnityEvent<int> { }

    private void Awake()
    {
        if (OnCoinValueChanged == null)
            OnCoinValueChanged = new IntEvent();
    }

    public void AddCoin(int value)
    {
        coinValue += value;
        OnCoinValueChanged?.Invoke(coinValue);
    }

}
