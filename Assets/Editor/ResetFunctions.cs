using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetFunctions : MonoBehaviour {

    [MenuItem("ResetFucntions/Reset All PlayerPrefs")]
    public static void ResetPlayerPrefs() {
        if (EditorUtility.DisplayDialog("Reset PlayerPrefs",
            "Are you sure you want to reset all PlayerPrefs? This action cannot be undone.",
            "Yes", "No")) {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            EditorUtility.DisplayDialog("Reset PlayerPrefs", "All PlayerPrefs have been reset.", "OK");
        }
    }

    [MenuItem("ResetFucntions/Reset GameData")]
    public static void ResetGameData() {
        if (EditorUtility.DisplayDialog("Reset GameData",
            "Are you sure you want to reset GameData? This action cannot be undone.",
            "Yes", "No")) {
            GameDataWriterReader.ResetGameData();
            EditorUtility.DisplayDialog("Reset GameData", "GameData have been reset.", "OK");
        }
    }
}
