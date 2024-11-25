using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour {
    public static DataManager Instance;
    public int highScore;
    public string highScorePlayerName;
    public string playerName;
    // Start is called before the first frame update

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
        Debug.Log("High score loaded: " + highScore);
        Debug.Log("Player name loaded: " + playerName);
    }

    [System.Serializable]
    class SaveData {
        public int highScore;
        public string playerName;
    }

    public void SetHighScoreValues(int score, string playerName) {
        if (score > highScore) {
            highScore = score;
            this.playerName = playerName;
            this.highScorePlayerName = playerName;
            SaveHighScore(score);
        }
    }

    public void SetPlayerName(string name) {
        playerName = name;
        Debug.Log("Player name set to: " + playerName); 
    }

    public void SaveHighScore(int score) {
        SaveData data = new() {
            highScore = highScore,
            playerName = playerName
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string jsonContent = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonContent);
            highScore = data.highScore;
            playerName = data.playerName;
            highScorePlayerName = playerName;
        } else {
            highScore = 0;
            playerName = "Player";
        }
    }
}
