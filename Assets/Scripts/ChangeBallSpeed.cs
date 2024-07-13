using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBallSpeed : MonoBehaviour {
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI currentSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float changeSpeed;

    private BallMovement movement;

    private void Start() {
        movement = GetComponent<BallMovement>();
        float currectSpeed=movement.GetSpeed();
        currentSpeed.text = ((int)currectSpeed).ToString();
        slider.value = currectSpeed / maxSpeed;
        slider.onValueChanged.AddListener(OnSliderValueChange);
    }

    private void OnSliderValueChange(float value) {
        float newSpeed = value * maxSpeed;
        movement.SetSpeed(newSpeed);
        currentSpeed.text = ((int)newSpeed).ToString();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            float newSpeed = Mathf.Clamp(movement.GetSpeed() + changeSpeed * Time.deltaTime, 0, maxSpeed);
            movement.SetSpeed(newSpeed);
            currentSpeed.text = ((int)newSpeed).ToString();
            slider.value = newSpeed / maxSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            float newSpeed = Mathf.Clamp(movement.GetSpeed() - changeSpeed * Time.deltaTime, 0, maxSpeed);
            movement.SetSpeed(newSpeed);
            currentSpeed.text = ((int)newSpeed).ToString();
            slider.value = newSpeed / maxSpeed;
        }
    }
}
