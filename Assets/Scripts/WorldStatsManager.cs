using System;
using UnityEngine;

public class WorldStatsManager : MonoBehaviour
{
    public static WorldStatsManager Instance;
    
    [Header("World Stats")]
    
    private int CoinsSpawned = 0;
    
    public int MaxCoinsSpawned;

    public int getCoinsSpawned()
    {
        return CoinsSpawned;
    }

    public int getMaxCoinsSpawned()
    {
        return MaxCoinsSpawned;
    }
    public void increaseCoinsSpawned()
    {
        CoinsSpawned++;
    }

    public void decreaseCoinsSpawned()
    {
        CoinsSpawned--;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
}
