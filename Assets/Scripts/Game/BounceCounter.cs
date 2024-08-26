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

    private void Awake() {
        movement = GetComponent<BallMovement>();

    }

    void Start() {
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

            GameDataWriterReader.UpdateLevelData();
        }
    }

    public int GetBouncesNumber() {
        return bouncesNumber;
    }

}
