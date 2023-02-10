using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System;
using System.Collections;

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
    }

    #endregion

    public int gameDifficulty = 0;
    public int levelSize = 6;
    public bool gameIsPlaying = false;

    [SerializeField]
    Transform blockGrid;

    //
    bool actionsNotBlocked = true;
    public bool ActionsNotBlocked
    {
        get => actionsNotBlocked;
        set
        {
            actionsNotBlocked = value;
            if (actionsNotBlocked)
            {
                StartCoroutine(CheckingBoardDelay());
            }
        }
    }

    int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    bool gameOver;
    public bool IsGameOver
    {
        get => gameOver;
        set
        {
            gameOver = value;
            GameOver();
        }
    }

    public TMP_Text scoreText;

    public void UpdateGameDifficulty(int newGameDifficulty)
    {
        gameDifficulty = newGameDifficulty;
        SetCurrentColors();
    }

    List<Color> availableColors { get; set; } = new List<Color>
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan,
        Color.magenta,
        Color.gray,
    };


    public List<Color> currentColors = new List<Color>();

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

    IEnumerator CheckingBoardDelay()
    {
        // Delay due to block destruction
        yield return new WaitForSeconds(.2f);
        if (!IsPossibleToFireBlock()) IsGameOver = true;
    }

    private bool IsPossibleToFireBlock()
    {
        Transform currentDifficulty = blockGrid.GetChild(GameManager.Instance.gameDifficulty);
        int numberOfBlocks = currentDifficulty.childCount;
        int minimumNumberOfBlocksToBlockBoard = levelSize * 8;

        // Checking if number of blocks is bigger then minimum number of blocks to block whole board
        if (numberOfBlocks >= minimumNumberOfBlocksToBlockBoard)
        {
            int numberOfBlocksAtTheBoundaryOfBoard = 0;
            foreach (Transform block in currentDifficulty)
            {
                if ((int)block.position.x == levelSize ||
                    (int)block.position.y == levelSize ||
                    (int)block.position.x == -levelSize ||
                    (int)block.position.y == -levelSize ) numberOfBlocksAtTheBoundaryOfBoard++;
            }

            if (numberOfBlocksAtTheBoundaryOfBoard == minimumNumberOfBlocksToBlockBoard)
            {
                ActionsNotBlocked = false;
                return false;
            }
        }

        return true;

    }

    void GameOver()
    {
        Debug.Log("Game over!");
    }
}


