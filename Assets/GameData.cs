using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Dictionary<int, int> highScores = new Dictionary<int, int>();

    public GameData(HighScore highScoreScript)
    {
        highScores = highScoreScript.highScores;
    }
}
