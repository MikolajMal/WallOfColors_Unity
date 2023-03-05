using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    HighScore highScore;

    Dictionary<int, int> scores = new Dictionary<int, int>();

    private void Start()
    {
        GameManager.Instance.OnGameDifficultyChange += UpdateScoreText;
        CurrentScore = 0;
    }

    public int CurrentScore
    {
        get
        {
            int currentDifficulty = GameManager.Instance.GameDifficulty;
            if (!scores.ContainsKey(currentDifficulty)) scores.Add(currentDifficulty, 0);
            return scores[currentDifficulty];
        }
        set
        {
            int currentDifficulty = GameManager.Instance.GameDifficulty;

            if (scores.ContainsKey(currentDifficulty)) scores[GameManager.Instance.GameDifficulty] = value;
            else scores.Add(currentDifficulty, value);

            highScore.CheckHighScore(value);

            UpdateScoreText();
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = CurrentScore.ToString();
    }
}
