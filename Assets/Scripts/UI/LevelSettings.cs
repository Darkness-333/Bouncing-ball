using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSettings : MonoBehaviour {
    [SerializeField] private int levelNumber;
    [SerializeField] private int maxCoins;

    [SerializeField] private TextMeshProUGUI collectedAndMaxCoinsText;
    [SerializeField] private TextMeshProUGUI levelNumberText;

    [SerializeField] private Button startLevelButton;

    private int collectedCoins;
    void Start() {
        startLevelButton.onClick.AddListener(() => SceneManager.LoadScene("Level " + levelNumber));
        LevelData levelData = GameDataWriterReader.ReadLevelData(levelNumber);
        if (levelData != null) {
            collectedCoins = levelData.maxCoinsCollected;
        }
        else {
            collectedCoins = 0;
        }
        collectedAndMaxCoinsText.SetText(collectedCoins.ToString() + "/" + maxCoins);
    }

    private void OnValidate() {
        levelNumberText.SetText(levelNumber.ToString());
        gameObject.name = "Level " + levelNumber.ToString();
        startLevelButton.onClick.AddListener(()=>SceneManager.LoadScene("Level "+levelNumber));
    }


}
