using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using System.IO;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public string playerName;
    public string bestPlayerName;
    public int bestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScore();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            bestScore = data.bestScore;
        }
    }
}
