using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    [SerializeField]
    Transform wall;
    WallOfColorsSetup wallOfColorsSetup;

    [SerializeField]
    Transform grid;
    BlockGrid blockGrid;

    Dictionary<int, GameObject> savedWalls = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> savedGrids = new Dictionary<int, GameObject>();
    Dictionary<int, int> savedScore = new Dictionary<int, int>();
    Dictionary<int, int> savedHighScore = new Dictionary<int, int>();

    void Start()
    {
        Debug.Log("TODO: all difficulty levels as scriptable objects...");

        wallOfColorsSetup = wall.GetComponent<WallOfColorsSetup>();
        blockGrid = grid.GetComponent<BlockGrid>();
    }

    public void SaveGameLocally()
    {
        GameManager.Instance.gameIsPlaying = false;


        int actualGameDifficulty = GameManager.Instance.gameDifficulty;

        // Saving blocks in wall
        Transform currentWall = wall.GetChild(actualGameDifficulty);
        currentWall.gameObject.SetActive(false);

        savedWalls.Remove(actualGameDifficulty);
        savedWalls.Add(actualGameDifficulty, currentWall.gameObject);

        //Saving blocks in on the board
        Transform currentGrid = grid.GetChild(actualGameDifficulty);
        currentGrid.gameObject.SetActive(false);

        savedGrids.Remove(actualGameDifficulty);
        savedGrids.Add(actualGameDifficulty, currentGrid.gameObject);

        // Saving score
        int currentScore = GameManager.Instance.Score;
        savedScore.Remove(actualGameDifficulty);
        savedScore.Add(actualGameDifficulty, currentScore);
    }

    public void RestoreGameLocally()
    {
        int actualGameDifficulty = GameManager.Instance.gameDifficulty;
        if (savedWalls.ContainsKey(actualGameDifficulty))
        {
            savedWalls[actualGameDifficulty].SetActive(true);
            savedGrids[actualGameDifficulty].SetActive(true);
            GameManager.Instance.Score = savedScore[actualGameDifficulty];
        }
        else
        {
            wallOfColorsSetup.SetupWall();
            blockGrid.SetupGrid();
            GameManager.Instance.Score = 0;
        }

        GameManager.Instance.gameIsPlaying = true;
    }

    //private void ClearBoard()
    //{
    //    List<GameObject> blocksToDestroy = new List<GameObject>();
    //    foreach (GameObject block in savedWalls[GameManager.Instance.gameDifficulty].transform)
    //    {
    //        blocksToDestroy.Add(block);
    //    }

    //    foreach (GameObject block in savedGrids[GameManager.Instance.gameDifficulty].transform)
    //    {
    //        blocksToDestroy.Add(block);
    //    }

    //    foreach (GameObject block in blocksToDestroy)
    //    {
    //        Destroy(block);
    //    }
    //}
}
