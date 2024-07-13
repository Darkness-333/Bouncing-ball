using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnParticleSystemFinish : MonoBehaviour {
    private ParticleSystem effect;

    void Start() {
        effect = GetComponent<ParticleSystem>();
    }

    void Update() {
        if (effect && !effect.IsAlive()) {
            Destroy(gameObject);
        }
    }
}


