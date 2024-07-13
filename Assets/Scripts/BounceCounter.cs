using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BounceCounter : MonoBehaviour {

    [SerializeField] private CoinCollector coinCollector;
    [SerializeField] private TextMeshProUGUI bounceNumberText;

    private BallMovement movement;
    private int bouncesNumber;

    void Start() {
        movement = GetComponent<BallMovement>();
        movement.bounceHappen += DecreaseBounceNumber;

        bouncesNumber = PlayerPrefs.GetInt(nameof(bouncesNumber), 20);

        bounceNumberText.text = bouncesNumber.ToString();

    }

    private void OnDisable() {
        movement.bounceHappen -= DecreaseBounceNumber;
    }

    private void DecreaseBounceNumber() {
        bouncesNumber = Mathf.Max(0, bouncesNumber - 1);
        bounceNumberText.text = bouncesNumber.ToString();
        if (bouncesNumber == 0) {
            movement.SetSpeed(0);
            movement.SetIsMoving(false);

            WriteLevelData();
        }
    }


    private void WriteLevelData() {
        string levelName = SceneManager.GetActiveScene().name;
        int levelNum = int.Parse(levelName.Substring(6, levelName.Length - 6));

        LevelData levelData = new LevelData();
        levelData.levelNumber = levelNum;

        LevelData currentLevelData = GameDataWriterReader.ReadLevelData(levelNum);

        if (currentLevelData == null) {
            levelData.maxCoinsCollected = coinCollector.getCollectedCoins();
        }
        else {
            levelData.maxCoinsCollected = Mathf.Max(coinCollector.getCollectedCoins(), currentLevelData.maxCoinsCollected);
        }
        GameDataWriterReader.WriteLevelData(levelData);

    }
}
