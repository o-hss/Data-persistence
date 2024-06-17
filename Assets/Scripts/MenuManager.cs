using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField playerNameInput;
    public Text playerInfoText;

    private string playerName;
    private int bestScore;
    private string bestPlayer;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestPlayer = PlayerPrefs.GetString("BestPlayer", "None");

        UpdatePlayerInfoText();
    }

    void UpdatePlayerInfoText()
    {
        playerInfoText.text = $"Best Score: {bestScore}\nBest Player: {bestPlayer}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMain()
    {
        // Сохранить имя игрока в PlayerPrefs
        playerName = playerNameInput.text;
        PlayerPrefs.SetString("CurrentPlayer", playerName);
        PlayerPrefs.Save();

        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

