using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public static ScoreCalculator instanse;

    [SerializeField]
    private Text _scoreText;
    private int _score;

    private void Start() {
        if (instanse == null) {
            instanse = this;
            DontDestroyOnLoad(this);
        }
    }

    public void ShiftScore(int score) {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }

}
