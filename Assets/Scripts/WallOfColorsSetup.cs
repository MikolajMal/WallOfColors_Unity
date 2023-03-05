using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallOfColorsSetup : BlocksSetup
{
    List<List<GameObject>> wallOfColors = new List<List<GameObject>>();

    public void SetupWall()
    {
        transform.position = Vector3.zero;
        transform.Translate(-Vector3.up * (levelSize + 1));

        SetSquareSize();

        int levelSizeInt = (int)levelSize;

        for (int i = -levelSizeInt; i <= levelSizeInt; i++)
        {
            List<GameObject> column = new List<GameObject>();

            for (int j = 0; j < 3; j++)
            {
                GameObject squareObj = Instantiate(square, new Vector3(i, transform.position.y - j), Quaternion.identity);
                squareObj.transform.parent = transform.GetChild(GameManager.Instance.GameDifficulty);
                if (j == 0) SetupFirstElementInColumn(squareObj);
                column.Add(squareObj);
            }

            wallOfColors.Add(column);
        }
    }

    void SetupFirstElementInColumn(GameObject colorBlock)
    {
        colorBlock.tag = "MovableBlock";
        BlockShooter blockShooter = colorBlock.AddComponent<BlockShooter>();
        blockShooter.wallOfColorsSetupScript = this;
    }

    public void UpdateColumn(GameObject clickedBlock)
    {
        List<GameObject> columnToUpdate = new List<GameObject>();

        // Searching for the clicked block in wallOfColors
        foreach (List<GameObject> column in wallOfColors)
        {
            foreach (GameObject colorBlock in column)
            {
                if (clickedBlock == colorBlock)
                {
                    columnToUpdate = column;
                    break;
                }
            }
        }

        // Removing clicked block
        columnToUpdate.Remove(clickedBlock);
        
        // Creating new block
        GameObject newColorBlock = Instantiate(square, columnToUpdate[1].transform.position, Quaternion.identity);
        newColorBlock.transform.parent = transform.GetChild(GameManager.Instance.GameDifficulty);
        columnToUpdate.Add(newColorBlock);

        // Updating positions for old blocks
        columnToUpdate[0].transform.position += Vector3.up;
        columnToUpdate[1].transform.position += Vector3.up;

        // Setup first block of column
        SetupFirstElementInColumn(columnToUpdate[0]);


    }
}
