using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOrExit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            GameDataWriterReader.UpdateLevelData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Destroy(GameMusic.Instance.gameObject);
            GameDataWriterReader.UpdateLevelData();
            SceneManager.LoadScene(0);
        }

    }
}
