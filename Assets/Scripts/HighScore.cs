using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    Dictionary<int, int> highScores = new Dictionary<int, int>();

    public static Action<int> onHighScoreChanges;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TODO: make a high score saving functionality locally for every difficulty level");
        Debug.Log("TODO: make a high score saving functionality locally");
        Debug.Log("TODO: make a high score display in main manu");
        Debug.Log("TODO: make use of High Score Updater script in every high score display");
    }

    public void CheckHighScore(int score)
    {
        int difficulty = GameManager.Instance.gameDifficulty;

        if (highScores.ContainsKey(difficulty))
        {
            if (highScores[difficulty] < score)
            {
                highScores[difficulty] = score;
                onHighScoreChanges?.Invoke(score);
            }
        }
        else
        {
            highScores.Add(difficulty, score);
            Debug.Log(highScores[difficulty]);
            onHighScoreChanges?.Invoke(score);
        }
    }
}
