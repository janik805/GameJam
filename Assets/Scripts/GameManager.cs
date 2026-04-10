using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas endText;
    public Canvas startText;
    public Canvas gameText;
    public Canvas pauseText;
    public static GameManager Instance;
    private Boolean gameRunning = false;
    private Boolean restart = false;

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
        Time.timeScale = 0f; // pauses game
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Start or pause game
            if (!gameRunning)
            {
                StartGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void GameOver()
    {
        endText.gameObject.SetActive(true);
        Time.timeScale = 0f; // pause game
        gameRunning = false;
    }

    private void StartGame()
    {
        startText.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        gameText.gameObject.SetActive(true);
        gameRunning = true;
        Time.timeScale = 1f;
        if (restart) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else
        {
            restart = true;
        }
    }

    private void PauseGame()
    {
        pauseText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        gameRunning = false;
        restart = false;
    }
}