using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance;
    [Header("Player Stats")]
    public  int health;

    public int speed;

    public int coins;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
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
        health -= damage;
    }
}
