using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BounceBust : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI currentPriceText;

    private int bouncesNumber;
    private int currentPrice;
    private int priceIncreaseCoeff = 5;
    private int bouncesIncrese = 20;

    private void Start() {
        currentPrice = PlayerPrefs.GetInt(nameof(currentPrice), 0);
        currentPriceText.SetText(currentPrice.ToString());
    }

    public void Buy() {
        GameData gameData = GameDataWriterReader.GetGameData();

        int allCollectedCoins = 0;
        foreach (LevelData levelData in gameData.levels) {
            allCollectedCoins += levelData.maxCoinsCollected;
        }
        if (allCollectedCoins >= currentPrice) {
            bouncesNumber = PlayerPrefs.GetInt(nameof(bouncesNumber), 20);
            PlayerPrefs.SetInt(nameof(bouncesNumber), bouncesNumber + bouncesIncrese);
            PlayerPrefs.SetInt(nameof(currentPrice), currentPrice + priceIncreaseCoeff);
            currentPrice = PlayerPrefs.GetInt(nameof(currentPrice), 0);
            currentPriceText.SetText(currentPrice.ToString());
        }

    }

}
