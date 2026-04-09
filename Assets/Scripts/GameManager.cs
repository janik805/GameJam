using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public static GameManager Instance;
    private Boolean gameOver = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }
}