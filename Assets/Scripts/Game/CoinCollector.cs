using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;
    public event Action<int> CoinCollected;
    public static int collectedCoins = 0;

    private void Start() {
        collectedCoins = 0;
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        Instantiate(effect, other.transform.position, Quaternion.identity);
        collectedCoins++;
        CoinCollected.Invoke(collectedCoins);
    }


}
