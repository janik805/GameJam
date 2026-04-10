using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{   
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI highscoreStartText;
    public TextMeshProUGUI highscoreEndText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score:" + PlayerStatsManager.Instance.GetCoins();
        healthText.text = "Health:" + PlayerStatsManager.Instance.GetHealth();
        highscoreStartText.text = "Highscore:" + PlayerStatsManager.Instance.GetHighscore();
        highscoreEndText.text = "Highscore:" + PlayerStatsManager.Instance.GetHighscore();    
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + PlayerStatsManager.Instance.GetCoins();
        healthText.text = "Health:" + PlayerStatsManager.Instance.GetHealth();
        highscoreStartText.text = "Highscore:" + PlayerStatsManager.Instance.GetHighscore();
        highscoreEndText.text = "Highscore:" + PlayerStatsManager.Instance.GetHighscore();    
    }
}
