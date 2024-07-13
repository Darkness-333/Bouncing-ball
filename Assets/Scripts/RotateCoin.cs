using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private Renderer rend;
    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate() {
        transform.RotateAround(rend.bounds.center, Vector3.up, rotationSpeed);
    }
    
}
