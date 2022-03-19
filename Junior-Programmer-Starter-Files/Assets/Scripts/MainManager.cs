using System.IO;
using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instanse;

    public Color TeamColor;

    private void Awake()
    {
        if (Instanse != null)
        {
            Destroy(gameObject);
            return;
        }

        Instanse = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    
    [Serializable]
    class SaveData
    {
        public Color TeamColor;

    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
