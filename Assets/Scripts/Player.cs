using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public string nameP;
    public int maxPoint;
    public string nameMax;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string nameMax;
        public int maxPoint;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.nameMax = nameP;
        data.maxPoint = maxPoint;

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

            nameMax = data.nameMax;
            maxPoint = data.maxPoint;
        }
    }
}
