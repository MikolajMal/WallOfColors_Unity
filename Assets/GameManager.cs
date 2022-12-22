using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int gameDifficulty=0;
    public static float levelSize = 6;
    public static bool boardRotationAllowed = true;

    static List<Color> availableColors { get; set; } = new List<Color>
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan,
        Color.magenta,
        Color.gray,
    };


    public static List<Color> currentColors = new List<Color>();

    private void Awake()
    {
        SetCurrentColors();
    }
    public static void SetCurrentColors()
    {
        currentColors.Clear();

        currentColors = gameDifficulty switch
        {
            0 => availableColors.Take(2).ToList(),
            1 => availableColors.Take(5).ToList(),
            2 => availableColors.Take(6).ToList(),
            3 => availableColors.Take(7).ToList(),
            _ => throw new System.NotImplementedException(),
        };
    }
}


