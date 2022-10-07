using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : Singleton<ScoreManager>
{
    public int bestScore;
    public string bestName;

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestName = bestName;

        string json = JsonUtility.ToJson(data);
        string path = $"{Application.dataPath}/Save/";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        File.WriteAllText($"{path}data.json", json);
    }

    public void LoadGameData()
    {
        string path = $"{Application.dataPath}/Save/";
        if (File.Exists($"{path}data.json"))
        {
            string json = File.ReadAllText($"{path}data.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestName = data.bestName;
        }
    }
}
