using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField] private ParticleSystem bounceEffect;
    [Range(0, 100)]
    [SerializeField] private float speed;

    public event Action bounceHappen;
    public bool isMoving = false;

    private Vector3 direction;
    private Rigidbody rb;
    private Vector3 normal;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void SetStartDirection(Vector3 startDirection) {
        if (startDirection != Vector3.zero && !isMoving) {
            direction = startDirection;
            rb.velocity = direction.normalized * speed;
            isMoving = true;
        }
    }

    void FixedUpdate() {
        if (!isMoving) return;

        Vector3 perpendicularVector = Vector3.Cross(direction, Vector3.up);
        transform.Rotate(-perpendicularVector * speed, Space.World);

        if (rb.velocity.magnitude < 0.9f * speed && isMoving) {
            Vector3 bounceDireciton = Vector3.Reflect(direction.normalized, normal);
            direction = bounceDireciton.normalized;
            rb.velocity = bounceDireciton.normalized * speed;

        }
    }

    private void OnCollisionStay(Collision collision) {
        if (!isMoving) return;

        if (collision.transform.tag.Equals("Wall") && rb.velocity.magnitude < .25 * speed) {
            rb.velocity = (normal + UnityEngine.Random.insideUnitSphere * 0.1f).normalized * speed;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (!isMoving) return;

        if (collision.transform.tag.Equals("Wall")) {
            normal = collision.contacts[0].normal;
            Vector3 bounceDireciton = Vector3.Reflect(direction.normalized, normal);
            direction = bounceDireciton.normalized;
            rb.velocity = bounceDireciton.normalized * speed;

            Quaternion rotation = Quaternion.LookRotation(normal, Vector3.right);
            Instantiate(bounceEffect, transform.position - normal * 0.5f, rotation);

            bounceHappen?.Invoke();

        }
    }

    public void SetIsMoving(bool isMoving) {
        this.isMoving = isMoving;
    }

    public Vector3 GetDirection() {
        return direction;
    }

    public float GetSpeed() {
        return speed;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
        if (!isMoving) return;

        rb.velocity=direction.normalized * speed;
    }

}
