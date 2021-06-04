using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue;
    public int CoinValue { get => coinValue; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerData>(out var data)){
            data.AddCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
