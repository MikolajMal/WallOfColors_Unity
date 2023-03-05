using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    TMP_Text highScoreText;

    Dictionary<int, int> highScores = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TODO: make a high score display in main manu");

        GameManager.Instance.OnGameDifficultyChange += UpdateHighScoreText;
    }

    public int CurrentHighScore
    {
        get
        {
            int currentDifficulty = GameManager.Instance.GameDifficulty;
            if (!highScores.ContainsKey(currentDifficulty)) highScores.Add(currentDifficulty, 0);
            return highScores[currentDifficulty];
        }
        set
        {
            int currentDifficulty = GameManager.Instance.GameDifficulty;
            if (highScores.ContainsKey(currentDifficulty)) highScores[GameManager.Instance.GameDifficulty] = value;
            else highScores.Add(currentDifficulty, value);

            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = CurrentHighScore.ToString();
    }

    public void CheckHighScore(int score)
    {
        CurrentHighScore = CurrentHighScore < score ? score : CurrentHighScore;
        UpdateHighScoreText();
    }
}
