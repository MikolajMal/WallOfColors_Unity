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
        Debug.Log("TODO: make a high score saving functionality locally for every difficulty level");
        Debug.Log("TODO: make a high score saving functionality locally");
        Debug.Log("TODO: make a high score display in main manu");
        Debug.Log("TODO: make use of High Score Updater script in every high score display");
    }

    public int CurrentHighScore
    {
        get
        {
            int currentDifficulty = GameManager.Instance.gameDifficulty;
            if (!highScores.ContainsKey(currentDifficulty)) highScores.Add(currentDifficulty, 0);
            return highScores[currentDifficulty];
        }
        set
        {
            int currentDifficulty = GameManager.Instance.gameDifficulty;
            if (highScores.ContainsKey(currentDifficulty))
            {
                highScores[GameManager.Instance.gameDifficulty] = value;
            }
            else
            {
                highScores.Add(currentDifficulty, value);
                UpdateHighScoreText(value);
            }
        }
    }

    void UpdateHighScoreText(int score)
    {
        highScoreText.text = score.ToString();
    }

    public void CheckHighScore(int score)
    {
        CurrentHighScore = CurrentHighScore < score ? score : CurrentHighScore;
        UpdateHighScoreText(CurrentHighScore);
    }
}
