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
            if (IsBoardEmpty(GameManager.Instance.gameDifficulty))
            {
                blockGrid.SetupGrid();
            }
        }
    }

    bool IsBoardEmpty(int gameDifficulty) => (transform.GetChild(gameDifficulty).childCount == 0) ? true : false;
}
