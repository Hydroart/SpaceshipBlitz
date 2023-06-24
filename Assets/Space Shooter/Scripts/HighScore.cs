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

    private void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey);
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();
    }

    private void UpdateHighScore(int points)
    {

            highScore += points;
            UpdateHighScoreText();
            SaveHighScore();

    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}