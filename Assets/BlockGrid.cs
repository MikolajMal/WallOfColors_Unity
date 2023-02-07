using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : BlocksSetup
{
    public int numberOfSquares = 5;

    List<Vector2> occupiedTiles = new List<Vector2>();

    public void SetupGrid(bool increaseBlocksAmount = false)
    {
        SetSquareSize();

        for (int i = 0; i < numberOfSquares; i++)
        {
            Vector2 currentPosition;
            do
            {
                int height = Mathf.RoundToInt(Random.Range(-levelSize, levelSize));
                int width = Mathf.RoundToInt(Random.Range(-levelSize, levelSize));

                currentPosition = new Vector2(height, width);
            } while (occupiedTiles.Contains(currentPosition));
            occupiedTiles.Add(currentPosition);
            GameObject squareObj = Instantiate(square, new Vector3(currentPosition.x, currentPosition.y), Quaternion.identity);
            squareObj.transform.parent = transform.GetChild(GameManager.Instance.gameDifficulty);// difficultyBoardPlaceHolder[GameManager.Instance.gameDifficulty];


        }
    }

    private void Update()
    {
        if (transform.childCount == 0 && !GameManager.Instance.GameOver) GameManager.Instance.GameOver = true;
    }
}
