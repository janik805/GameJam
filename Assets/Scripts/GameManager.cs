using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public static GameManager Instance;
    private Boolean gameRunning = false;
    private Boolean gameStarted = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f; // Zeit wird beim Start gestoppt
    }

    // Update is called once per frame
    void Update()
    {
        // Startet Spiel mit der Leertaste
        if (!gameRunning && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        gameRunning = true;
        Time.timeScale = 1f;
        if (gameStarted) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else
        {
            gameStarted = true;
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f; // Stops game
        gameRunning = false;
    }
}