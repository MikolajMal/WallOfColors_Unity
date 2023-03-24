using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Dictionary<int, int> highScores = new Dictionary<int, int>();
    public Dictionary<int, int> scores = new Dictionary<int, int>();

    public Dictionary<int, int> numberOfBlocksOnLevel = new Dictionary<int, int>();

    public GameData(HighScore highScoreScript, Score score, BlockGrid blockGrid)
    {
        highScores = highScoreScript.highScores;
        scores = score.scores;

        numberOfBlocksOnLevel = blockGrid.numberOfBlocksOnLevel;
    }
}
