using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataSaver : MonoBehaviour
{
    public static DataSaver instance;
    public string playerName;
    string saveFilePath;
    //public static SaveData data;

    void Awake()
    {
        //Debug.Log(playerName == null);
        //Debug.Log(playerName == "");
        if (instance == null)
        {
            saveFilePath = Application.persistentDataPath + "/bestscore.json";
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Serializable]
    public class SaveData
    {
        public int bestScore;
        public string bestPlayerName;
    }

    public void SaveDataFile(int bestScore)
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestPlayerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }
    public SaveData LoadDataFile()
    {
        if (!File.Exists(saveFilePath))
            return null;
        string text = File.ReadAllText(saveFilePath);
        SaveData data = JsonUtility.FromJson<SaveData>(text);
        
        return data;
    }

    public string NewBestScoreText(SaveData bestScoreData)
    {
        if (bestScoreData != null)
        {
            return $"Best Score:{bestScoreData.bestPlayerName}:{bestScoreData.bestScore}";
        }
        return "Best Score::0";
    }
}
