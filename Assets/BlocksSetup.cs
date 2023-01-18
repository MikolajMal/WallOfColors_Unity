using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSetup : MonoBehaviour
{
    protected int levelSize = GameManager.levelSize;
    protected float blockSize = 1f;
    public GameObject square;

    protected void SetSquareSize()
    {
        square.GetComponent<SpriteRenderer>().size = new Vector2(blockSize, blockSize);
    }
}
