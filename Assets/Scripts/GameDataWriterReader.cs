using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataWriterReader {
    private static GameData gameData;
    private static string dataPath = Path.Combine(Application.persistentDataPath, "gamedata.json");

    private static void UpdateGameData() {
        if (File.Exists(dataPath)) {
            string json = File.ReadAllText(dataPath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else {
            gameData = new GameData();
        }
    }

    public static void ResetGameData() {
        string json = JsonUtility.ToJson(new GameData());
        File.WriteAllText(dataPath, json);
    }
    public static GameData GetGameData() {
        UpdateGameData();
        return gameData;
    }

    public static void WriteLevelData(LevelData newLevelData) {
        UpdateGameData();
        bool levelExists = false;
        foreach (LevelData level in gameData.levels) {
            if (level.levelNumber == newLevelData.levelNumber) {
                level.levelNumber = newLevelData.levelNumber;
                level.maxCoinsCollected = newLevelData.maxCoinsCollected;
                levelExists = true;
            }
        }
        if (!levelExists) {
            gameData.levels.Add(newLevelData);
        }
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(dataPath, json);
    }

    public static LevelData ReadLevelData(int levelNumber) {
        UpdateGameData();
        foreach (LevelData level in gameData.levels) {
            if (level.levelNumber == levelNumber) {
                return level;
            }
        }
        return null;
    }

    public static void UpdateLevelData() {
        string levelName = SceneManager.GetActiveScene().name;
        if(!int.TryParse(levelName.Substring(6, levelName.Length - 6), out int res)) {
            return;
        }
        int levelNum = int.Parse(levelName.Substring(6, levelName.Length - 6));

        LevelData levelData = new LevelData();
        levelData.levelNumber = levelNum;

        LevelData currentLevelData = ReadLevelData(levelNum);

        if (currentLevelData == null) {
            levelData.maxCoinsCollected = CoinCollector.collectedCoins;
        }
        else {
            levelData.maxCoinsCollected = Mathf.Max(CoinCollector.collectedCoins, currentLevelData.maxCoinsCollected);
        }
        WriteLevelData(levelData);

    }
}


