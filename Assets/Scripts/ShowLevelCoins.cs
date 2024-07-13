using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLevelCoins : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI collectedAndMaxCoinsText;
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private int maxCoins;
    private int collectedCoins;
    void Start() {
        LevelData levelData = GameDataWriterReader.ReadLevelData(int.Parse(levelNumberText.text));
        if (levelData != null ) {
            collectedCoins = levelData.maxCoinsCollected;
        }
        else {
            collectedCoins=0;
        }
        collectedAndMaxCoinsText.SetText(collectedCoins.ToString() + "/" + maxCoins);
    }

}
