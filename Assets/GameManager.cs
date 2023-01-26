using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        SetCurrentColors();
        score = 0;
        scoreText.text = "Score: " + score;
        staticScoreText = scoreText;
    }

    #endregion

    public int gameDifficulty = 0;
    public int levelSize = 6;
    public bool actionsNotBlocked = true;

    [SerializeField]
    Transform blockGrid;

    int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            staticScoreText.text = "Score: " + score;
        }
    }

    bool gameOver;
    public bool GameOver
    {
        get => gameOver;
        set
        {
            gameOver = value;
            LevelFinished();
        }
    }

    public TMP_Text scoreText;
    static TMP_Text staticScoreText;

    static List<Color> availableColors { get; set; } = new List<Color>
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan,
        Color.magenta,
        Color.gray,
    };


    public static List<Color> currentColors = new List<Color>();

    public void SetCurrentColors()
    {
        currentColors.Clear();

        currentColors = gameDifficulty switch
        {
            0 => availableColors.Take(2).ToList(),
            1 => availableColors.Take(3).ToList(),
            2 => availableColors.Take(4).ToList(),
            3 => availableColors.Take(5).ToList(),
            4 => availableColors.Take(6).ToList(),
            5 => availableColors.Take(7).ToList(),
            _ => throw new System.NotImplementedException(),
        };
    }

    void LevelFinished()
    {
        Debug.Log("Level completed!");
    }
}


