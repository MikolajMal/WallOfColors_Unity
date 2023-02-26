using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : BlocksSetup
{
    public int increaseAmountNumberOfSquares = 5;

    List<Vector2> occupiedTiles = new List<Vector2>();

    Dictionary<int, int> numberOfBlocksOnLevel = new Dictionary<int, int>();

    protected override void Start()
    {
        base.Start();

        numberOfBlocksOnLevel.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            numberOfBlocksOnLevel.Add(i, increaseAmountNumberOfSquares);
        }
    }

    public void SetupGrid(bool increaseBlocksAmount = false)
    {
        SetSquareSize();

        occupiedTiles.Clear();

        int numberOfSquares;

        if (increaseBlocksAmount) numberOfBlocksOnLevel[GameManager.Instance.gameDifficulty] += increaseAmountNumberOfSquares;
        else numberOfBlocksOnLevel[GameManager.Instance.gameDifficulty] = increaseAmountNumberOfSquares;

        numberOfSquares = numberOfBlocksOnLevel[GameManager.Instance.gameDifficulty];


        for (int i = 0; i < numberOfSquares; i++)
        {
            Vector2 currentPosition;
            do
            {
                int height = Mathf.RoundToInt(Random.Range(-levelSize, levelSize + 1));
                int width = Mathf.RoundToInt(Random.Range(-levelSize, levelSize + 1));

                currentPosition = new Vector2(height, width);
            } while (occupiedTiles.Contains(currentPosition));
            occupiedTiles.Add(currentPosition);
            GameObject squareObj = Instantiate(square, new Vector3(currentPosition.x, currentPosition.y), Quaternion.identity);
            squareObj.transform.parent = transform.GetChild(GameManager.Instance.gameDifficulty);// difficultyBoardPlaceHolder[GameManager.Instance.gameDifficulty];


        }
    }
}
