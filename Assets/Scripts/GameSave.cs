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

    [SerializeField]
    Score scoreScript;

    Dictionary<int, GameObject> savedWalls = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> savedGrids = new Dictionary<int, GameObject>();

    void Start()
    {
        wallOfColorsSetup = wall.GetComponent<WallOfColorsSetup>();
        blockGrid = grid.GetComponent<BlockGrid>();
    }

    public void SaveGameLocally()
    {
        GameManager.Instance.gameIsPlaying = false;


        int actualGameDifficulty = GameManager.Instance.GameDifficulty;

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
    }

    public void RestoreGameLocally()
    {
        int actualGameDifficulty = GameManager.Instance.GameDifficulty;
        if (savedWalls.ContainsKey(actualGameDifficulty))
        {
            savedWalls[actualGameDifficulty].SetActive(true);
            savedGrids[actualGameDifficulty].SetActive(true);
        }
        else
        {
            wallOfColorsSetup.SetupWall();
            blockGrid.SetupGrid();
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
