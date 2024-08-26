using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCoin : MonoBehaviour
{
    [SerializeField] private CoinCollector collector;
    [SerializeField] private TextMeshProUGUI coinText;
    private void OnEnable() {
        collector.CoinCollected += UpdateCoin;
    }

    private void OnDisable() {
        collector.CoinCollected -= UpdateCoin;
    }

    private void UpdateCoin(int coins) {
        coinText.SetText(coins.ToString());
    }

}
