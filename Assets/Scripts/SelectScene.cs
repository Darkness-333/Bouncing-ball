using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    public void SelectSceneByNumber(int sceneNumber) {
        SceneManager.LoadScene("Level "+sceneNumber);
    }
}
