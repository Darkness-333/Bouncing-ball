using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject levelsUI;
    [SerializeField] private GameObject storeUI;

    public void SwitchBetweenStoreAndLevels() {
        levelsUI.SetActive(!levelsUI.activeSelf);
        storeUI.SetActive(!storeUI.activeSelf);
    }

}
