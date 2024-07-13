using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataWriterReader {
    private static GameData gameData;
    private static string dataPath = Path.Combine(Application.persistentDataPath, "gamedata.json");

    private static void UpdateData() {
        if (File.Exists(dataPath)) {
            string json = File.ReadAllText(dataPath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else {
            gameData = new GameData();
        }
    }

    public static GameData GetGameData() {
        UpdateData();
        return gameData;
    }

    public static void WriteLevelData(LevelData newLevelData) {
        UpdateData();
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
        UpdateData();
        foreach (LevelData level in gameData.levels) {
            if (level.levelNumber == levelNumber) {
                return level;
            }
        }
        return null;
    }
}


