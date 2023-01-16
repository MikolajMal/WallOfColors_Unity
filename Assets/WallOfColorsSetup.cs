using System.Collections.Generic;
using UnityEngine;

public class WallOfColorsSetup : BlocksSetup
{
    List<List<GameObject>> wallOfColors = new List<List<GameObject>>();

    private void Start()
    {
        transform.Translate(-Vector3.up*(levelSize + 1));

        SetSquareSize();

        int levelSizeInt = (int)levelSize;

        for (int i = -levelSizeInt; i <= levelSizeInt; i++)
        {
            List<GameObject> column = new List<GameObject>();

            for (int j = 0; j < 3; j++)
            {
                GameObject squareObj = Instantiate(square, new Vector3(i, transform.position.y - j), Quaternion.identity);
                squareObj.transform.parent = transform;
                if (j == 0) SetupFirstElementInColumn(squareObj);
                column.Add(squareObj);
            }

            wallOfColors.Add(column);
        }
    }

    void SetupFirstElementInColumn(GameObject colorBlock)
    {
        colorBlock.tag = "MovableBlock";
        colorBlock.AddComponent<BlockShooter>();
    }
}
