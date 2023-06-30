using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScore : MonoBehaviour
{
    public static int highScore = 0;
    public Text highScoreText;

    private const string HighScoreKey = "HighScore";

    private void Start()
    {

        UpdateHighScoreText();
        Enemy.OnScoreUpdate += UpdateHighScore;
    }

    private void OnDestroy()
    {
        Enemy.OnScoreUpdate -= UpdateHighScore;
    }

    public void UpdateHighScore(int points)
    {

            highScore += points;
            UpdateHighScoreText();

    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}