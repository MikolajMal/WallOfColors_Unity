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

    Dictionary<int, List<GameObject>> savedWalls = new Dictionary<int, List<GameObject>>();
    Dictionary<int, List<GameObject>> savedGrids = new Dictionary<int, List<GameObject>>();

    void Start()
    {
        wallOfColorsSetup = wall.GetComponent<WallOfColorsSetup>();
        blockGrid = grid.GetComponent<BlockGrid>();
    }

    public void SaveGameLocally()
    {
        int actualGameDifficulty = GameManager.Instance.gameDifficulty;

        List<GameObject> wallElements = new List<GameObject>();

        foreach (Transform wallChild in wall.GetChild(actualGameDifficulty))
        {
            wallChild.gameObject.SetActive(false);
            wallElements.Add(wallChild.gameObject);
        }

        savedWalls.Remove(actualGameDifficulty);
        savedWalls.Add(actualGameDifficulty, wallElements);

        List<GameObject> gridElements = new List<GameObject>();

        foreach (Transform gridChild in grid.GetChild(actualGameDifficulty))
        {
            gridChild.gameObject.SetActive(false);
            wallElements.Add(gridChild.gameObject);
        }

        savedGrids.Remove(actualGameDifficulty);
        savedGrids.Add(actualGameDifficulty, gridElements);
    }

    public void RestoreGameLocally()
    {
        int actualGameDifficulty = GameManager.Instance.gameDifficulty;
        if (savedWalls.ContainsKey(actualGameDifficulty))
        {
            foreach (GameObject wallBlock in savedWalls[actualGameDifficulty])
            {
                wallBlock.SetActive(true);
            }

            foreach (GameObject gridBlock in savedGrids[actualGameDifficulty])
            {
                gridBlock.SetActive(true);
            }
        }
        else
        {
            wallOfColorsSetup.SetupWall();
            blockGrid.SetupGrid();
        }

    }

    private void ClearBoard()
    {
        List<GameObject> blocksToDestroy = new List<GameObject>();
        blocksToDestroy.AddRange(savedWalls[GameManager.Instance.gameDifficulty]);
        blocksToDestroy.AddRange(savedGrids[GameManager.Instance.gameDifficulty]);

        foreach (GameObject block in blocksToDestroy)
        {
            Destroy(block);
        }
    }
}
