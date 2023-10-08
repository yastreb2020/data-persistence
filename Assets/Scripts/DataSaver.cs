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

    void Awake()
    {
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

    public void SaveDataFile(string playerName, int bestScore)
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

}
