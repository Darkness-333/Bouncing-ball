using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public List<LevelData> levels = new List<LevelData>();
}
[System.Serializable]
public class LevelData {
    public int levelNumber;
    public int maxCoinsCollected;
}
