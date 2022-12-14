using System.Collections.Generic;
using UnityEngine;

public class WallOfColorsSetup : BlocksSetup
{
    private void Start()
    {
        transform.Translate(-Vector3.up*(levelSize + 1));

        SetSquareSize();

        int levelSizeInt = (int)levelSize;

        for (int i = -levelSizeInt; i <= levelSizeInt; i++)
        {
            GameObject squareObj = Instantiate(square, new Vector3(i, transform.position.y), Quaternion.identity);
            squareObj.transform.parent = transform;
            squareObj.tag = "MovableBlock";
            squareObj.AddComponent<BlockShooter>();
        }
    }
}
