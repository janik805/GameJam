using System;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance;
    [Header("Player Stats")]
    [SerializeField] private  int health;

    [SerializeField] private int speed;

    [SerializeField] private int coins;
    [SerializeField] private int highscore;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    public int GetCoins()
    {
        return coins;
    }
    
    public int  GetSpeed()
    {
        return speed;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        this.health = newHealth;
    }

    public void SetSpeed(int newSpeed)
    {
        this.speed = newSpeed;
    }

    public void GiveCoins(int amount)
    {
        this.coins += amount;
    }

    public void TakeCoins(int amount)
    {
        this.coins -= amount;
    }
    
    public void TakeDamage(int damage)
    {   
        if (health > damage)
        {
            health -= damage;
        } else
        {
            health = 0;
            GameManager.Instance.GameOver();
        }
    }

    public Boolean SetHighscore()
    {
        if (coins > highscore)
        {
            highscore = coins;
            PlayerPrefs.SetInt("Highscore", coins);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }

    public int GetHighscore()
    {
        return highscore;
    }
}
