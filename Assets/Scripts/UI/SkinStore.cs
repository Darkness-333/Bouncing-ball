using System;
using UnityEngine;

public class SkinStore : MonoBehaviour {
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Skin[] skins;

    private void Start() {
        int index = GetSkinIndex();
        skins[index].Select(true);


    }

    public void SelectSkin(Skin skin) {
        int index = Array.IndexOf(skins, skin);

        if (index != -1) {
            if (uiManager.allCollectedCoins >= skins[index].GetCost()) {
                PlayerPrefs.SetInt("SelectedSkin", index);
                for (int i = 0; i < skins.Length; i++) {
                    if (i == index) {
                        skins[i].Select(true);
                    }
                    else {
                        skins[i].Select(false);

                    }
                }
            }
        }
    }

    public static int GetSkinIndex() {
        return PlayerPrefs.GetInt("SelectedSkin", 0);
    }
}
