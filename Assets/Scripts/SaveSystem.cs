using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    HighScore highScore;
    [SerializeField]
    Score score;

    [SerializeField]
    BlockGrid blockGridScript;

    BinaryFormatter formatter = new BinaryFormatter();

    string path;

    private void Awake()
    {
        path = Application.persistentDataPath +  "/saved.game";
        LoadGame();
        StartCoroutine(SaveGameCoroutine());
    }

    public void SaveGame()
    {
        GameData gameData = new GameData(highScore, score, blockGridScript);

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, gameData);
        }
    }

    void LoadGame()
    {
        if (File.Exists(path))
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                GameData gameData = formatter.Deserialize(stream) as GameData;

                highScore.highScores = gameData.highScores;
                score.scores = gameData.scores;

                blockGridScript.numberOfBlocksOnLevel = gameData.numberOfBlocksOnLevel;
            }
        }
        else
        {
            Debug.Log("Can not finde saved.game file in: " + path);
        }
    }

    IEnumerator SaveGameCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            SaveGame();
        }
    }

    //private void OnApplicationQuit()
    //{
    //    SaveGame();
    //}

    //private void OnApplicationPause(bool pause)
    //{
    //    SaveGame();
    //}

    //private void OnApplicationFocus(bool focus)
    //{
    //    SaveGame();
    //}
}
