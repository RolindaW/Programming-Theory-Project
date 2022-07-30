using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    // ENCAPSULATION
    private const int MAX_NAME_LENGTH = 3;
    
    // ENCAPSULATION
    public static ConfigurationManager Instance { get; private set; }

    // ENCAPSULATION
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (IsValidName(value))
            {
                _name = value;
            }
        }
    }

    public string HighScoreName;
    public int HighScoreValue;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        LoadData();
    }

    // ABSTRACTION
    public bool IsValidName(string name)
    {
        return !string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) && name.Length <= MAX_NAME_LENGTH;
    }

    [Serializable]
    private class HighScore
    {
        public string name;
        public int score;

        public HighScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public void SaveData()
    {
        HighScore highScore = new HighScore(HighScoreName, HighScoreValue);
        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(GetSettingsDataPath(), json);
    }

    public void LoadData()
    {
        string path = GetSettingsDataPath();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore highScore = JsonUtility.FromJson<HighScore>(json);
            HighScoreName = highScore.name;
            HighScoreValue = highScore.score;
        }
    }

    private string GetSettingsDataPath()
    {
        return string.Format("{0}/{1}", Application.persistentDataPath, "custom_settings.json");
    }
}
