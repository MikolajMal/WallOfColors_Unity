using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardReset : MonoBehaviour
{
    BlockGrid blockGrid;

    private void Start()
    {
        blockGrid = GetComponent<BlockGrid>();
    }

    void Update()
    {
        if (GameManager.Instance.gameIsPlaying)
        {
            if (IsBoardEmpty(GameManager.Instance.GameDifficulty) && (GameManager.Instance.Score != 0))
            {
                blockGrid.SetupGrid(true);
            }
        }
    }

    bool IsBoardEmpty(int gameDifficulty) => (transform.GetChild(gameDifficulty).childCount == 0) ? true : false;

    public void ResetBoard()
    {
        GameManager.Instance.Score = 0;

        ClearBoard();

        blockGrid.SetupGrid();

        GameManager.Instance.ActionsNotBlocked = true;
    }

    void ClearBoard()
    {
        foreach (Transform block in transform.GetChild(GameManager.Instance.GameDifficulty))
        {
            Destroy(block.gameObject);
        }
    }


}
