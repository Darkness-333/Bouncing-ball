using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowAllCollectedCoins : MonoBehaviour
{
    private TextMeshProUGUI allCollectedCoinsText;
    void Start()
    {
        allCollectedCoinsText = GetComponent<TextMeshProUGUI>();
        GameData gameData=GameDataWriterReader.GetGameData();

        int allCollectedCoins = 0;
        foreach (LevelData levelData in gameData.levels) {
            allCollectedCoins += levelData.maxCoinsCollected;
        }
        allCollectedCoinsText.SetText(allCollectedCoins.ToString());
    }


}
