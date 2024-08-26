using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCollection : MonoBehaviour {
    [SerializeField] private MeshRenderer[] skins;

    void Start() {
        GameObject ball= GameObject.Find("Ball");
        if(ball != null) {
            int skinIndex = SkinStore.GetSkinIndex();
            ball.GetComponent<MeshRenderer>().material = skins[skinIndex].material;
        }

    }

}
