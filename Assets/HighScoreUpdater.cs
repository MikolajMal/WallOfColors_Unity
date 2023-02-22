using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreUpdater : MonoBehaviour
{
    [SerializeField]
    TMP_Text highScoreText;

    private void Awake()
    {
        HighScore.onHighScoreChanges += UpdateHighScoreText;
    }

    void UpdateHighScoreText(int score)
    {
        highScoreText.text = score.ToString();
    }
}
