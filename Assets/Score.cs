using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    Dictionary<int, int> scores = new Dictionary<int, int>();

    public int CurrentScore
    {
        get
        {
            int currentDifficulty = GameManager.Instance.gameDifficulty;
            if (!scores.ContainsKey(currentDifficulty)) scores.Add(currentDifficulty, 0);
            return scores[currentDifficulty];
        }
        set
        {
            int currentDifficulty = GameManager.Instance.gameDifficulty;
            if (scores.ContainsKey(currentDifficulty))
            {
                scores[GameManager.Instance.gameDifficulty] = value;
            }
            else
            {
                scores.Add(currentDifficulty, value);
                UpdateScoreText(value);
            }
        }
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
