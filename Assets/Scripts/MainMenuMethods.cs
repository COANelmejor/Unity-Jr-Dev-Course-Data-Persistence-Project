using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MainMenuMethods : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    public void LoadGame() {
        // Load the game scene
        SceneManager.LoadScene("main");
    }

    public void QuitGame() {
        // Quit the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void SetPlayerName(string name) {
        // Set the player name
        DataManager.Instance.SetPlayerName(name);
    }

    public void SetHighScoreText() {
        highScoreText.text = $"High Score: {DataManager.Instance.highScore} by {DataManager.Instance.playerName}";
    }

    void Awake() {
        SetHighScoreText();
    }
}
