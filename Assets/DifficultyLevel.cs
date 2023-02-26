using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = " Difficulty Level")]
public class DifficultyLevel : ScriptableObject
{
    public int difficultyLevel;
    public int score;
    public int highScore;

    public GameObject wall;
    public GameObject grid;
}
