using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    Dictionary<int, int> highScores = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TODO: make a high score saving functionality locally");
        Debug.Log("TODO: make a high score display in main manu");
    }

    public void CheckHighScore(int score)
    {
        int difficulty = GameManager.Instance.gameDifficulty;

        if (highScores.ContainsKey(difficulty))
        {
            if (highScores[difficulty] < score)
            {
                highScores[difficulty] = score;
            }
        }
        else
        {
            highScores.Add(difficulty, score);
        }
    }
}
