using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{   
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI highscoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score:" + PlayerStatsManager.Instance.GetCoins();
        healthText.text = "Health:" + PlayerStatsManager.Instance.GetHealth();
        highscoreText.text = "Highscore:" + PlayerStatsManager.Instance.GetHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + PlayerStatsManager.Instance.GetCoins();
        healthText.text = "Health:" + PlayerStatsManager.Instance.GetHealth();
        highscoreText.text = "Highscore:" + PlayerStatsManager.Instance.GetHighscore();
    }
}
