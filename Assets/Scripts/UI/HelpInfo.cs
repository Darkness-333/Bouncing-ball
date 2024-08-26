using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpInfo : MonoBehaviour {
    [SerializeField] private GameObject firstHint;
    [SerializeField] private GameObject info;

    private bool needFirstHint;


    void Start() {
        needFirstHint = PlayerPrefs.GetInt(nameof(needFirstHint), 1) == 1;
        if (needFirstHint) {
            firstHint.SetActive(true);
        }
    }

    public void OpenInfo() {
        if(needFirstHint) {
            PlayerPrefs.SetInt(nameof(needFirstHint), 0);
            firstHint.SetActive(false);
        }
        info.SetActive(true);
    }

    public void CloseInfo() {
        info.SetActive(false);

    }

}
