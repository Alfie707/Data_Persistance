using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ReadInput : MonoBehaviour
{   
    public static ReadInput Instance;
    public TMP_Text BestScore;

    public string userName ;
    public int highScore;
    [System.Serializable]
    class PlayerData
    {
        public string userName;
        public int highScore;
    }
    
    public  TMP_InputField input;
    // Start is called before the first frame update
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
            
    }

    private void Start()
    {
        LoadHighscore();
        BestScore.text = $"Best Score : {userName} : {highScore}"; 
    }

    
    public void UpdateScore(string playerName, int newScore)
    {
        PlayerData entry = new PlayerData();
        // highScore = PlayerPrefs.GetInt("highScore", 0);
        // userName = PlayerPrefs.GetString("player", playerName);
        entry.userName = playerName;
        entry.highScore = newScore;
        string json = JsonUtility.ToJson(entry);
        File.WriteAllText(Application.persistentDataPath + "/Highscoresfile.json", json);
        Debug.Log(Application.persistentDataPath);
        Debug.Log("Highs score updated" + userName + highScore);

        
    }


    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/Highscoresfile.json";

        if(File.Exists(path) )
        {   
            string json = File.ReadAllText(path);
            PlayerData entry = JsonUtility.FromJson<PlayerData>(json);
            userName = entry.userName;
            highScore = entry.highScore;         
        }

        Debug.Log("Highs score loaded " + userName + highScore);

    }

    public void ReadString()
    {   
        userName = input.text;
    }
}
