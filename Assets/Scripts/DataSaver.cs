using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataSaver : MonoBehaviour
{
    public static DataSaver instance;
    private static string saveFilePath;
    public static SaveData saveData;

    void Awake()
    {
        if (instance == null)
        {
            saveFilePath = Application.persistentDataPath + "/bestscore.json";
            saveData = LoadDataFile();
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
        public string currentPlayer;
    }

    [Serializable]
    public class PlayerInfo
    {
        public string name;
    }

    public static void SaveDataFile()
    {
        if (saveData != null)
        {
            string json = JsonUtility.ToJson(saveData);
            File.WriteAllText(saveFilePath, json);
        }
    }
    public SaveData LoadDataFile()
    {
        if (!File.Exists(saveFilePath))
        {
            saveData = new SaveData { bestPlayerName = "", bestScore = 0, currentPlayer = "" };
        }
        else
        {
            string text = File.ReadAllText(saveFilePath);
            saveData = JsonUtility.FromJson<SaveData>(text);
        }

        return saveData;
    }

    public string NewBestScoreText()
    {
        //if (saveData != null)
        //{
            return $"Best Score:{saveData.bestPlayerName}:{saveData.bestScore}";
        //}
        //return "Best Score::0";
    }
}
