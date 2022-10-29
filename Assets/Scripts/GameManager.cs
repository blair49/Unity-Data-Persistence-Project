using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string currentPlayerName;
    public string bestPlayerName;
    public int bestScore;

    void Awake()
    {
        bestPlayerName = "";
        bestScore = 0;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();
    }

    [System.Serializable]
    public class GameData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveData()
    {
        GameData gameData = new GameData();
        gameData.playerName = bestPlayerName;
        gameData.bestScore = bestScore;

        string jsonData = JsonUtility.ToJson(gameData);

        File.WriteAllText(Application.persistentDataPath + "/gameData.json", jsonData);
    }

    void LoadData()
    {
        string saveFilePath = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
            bestPlayerName = gameData.playerName;
            bestScore = gameData.bestScore;
        }
    }


}
