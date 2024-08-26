using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject levelsUI;
    [SerializeField] private GameObject buffStoreUI;
    [SerializeField] private GameObject skinStoreUI;

    [SerializeField] private TextMeshProUGUI[] allCollectedCoinsTexts;
    public int allCollectedCoins {  get; private set; }
    private void Awake() {
        GameData gameData = GameDataWriterReader.GetGameData();

        allCollectedCoins = 0;
        foreach (LevelData levelData in gameData.levels) {
            allCollectedCoins += levelData.maxCoinsCollected;
        }
        
    }

    private void Start() {
        foreach(TextMeshProUGUI elem in allCollectedCoinsTexts) {
            elem.SetText(allCollectedCoins.ToString());
        }
    }

    public void SwitchBetweenBuffStoreAndLevels() {
        levelsUI.SetActive(!levelsUI.activeSelf);
        buffStoreUI.SetActive(!buffStoreUI.activeSelf);
    }

    public void SwitchBetweenSkinStoreAndLevels() {
        levelsUI.SetActive(!levelsUI.activeSelf);
        skinStoreUI.SetActive(!skinStoreUI.activeSelf);
    }

}
