using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByBallDirection : MonoBehaviour
{
    [SerializeField] private BallMovement movement;

    private void FixedUpdate() {
        Vector3 direction = movement.GetDirection();
        Vector3 lookAtPosition = transform.position - direction;
        transform.LookAt(lookAtPosition);

    }
}
