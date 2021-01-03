using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartHelper : MonoBehaviour
{
    public static RestartHelper instanse;

    public Button restartButton;
    public SceneAsset mainSceneAsset;

    private void Start()
    {
        if (instanse == null) {
            instanse = this;
            DontDestroyOnLoad(this);
        }
        restartButton.onClick.AddListener(Reset);
        Time.timeScale = 1.0F;
    }

    private void Reset() {
        SceneManager.LoadScene(mainSceneAsset.name);
    }

    public void ShowRestartButton() {
        if (!restartButton.IsActive()) {
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0F;
        }
    }
}
