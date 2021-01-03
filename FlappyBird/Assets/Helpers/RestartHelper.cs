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
        instanse = this;
        DontDestroyOnLoad(this);
        restartButton.onClick.AddListener(Reset);
    }

    public void Reset() {
        SceneManager.LoadScene(mainSceneAsset.name);
        Time.timeScale = 1.0F;
        restartButton.gameObject.SetActive(false);
    }
}
