using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{   
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score:" + PlayerStatsManager.Instance.GetCoins();
        healthText.text = "Health:"+PlayerStatsManager.Instance.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + PlayerStatsManager.Instance.GetCoins();
        healthText.text = "Health:" + PlayerStatsManager.Instance.GetHealth();
    }
}
