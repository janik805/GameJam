using System;
using UnityEngine;

public class WorldStatsManager : MonoBehaviour
{
    public static WorldStatsManager Instance;
    
    [Header("World Stats")]
    
    private int CoinsSpawned = 0;
    
    [SerializeField] private int MaxCoinsSpawned;
    
    public GameObject plane;
    private float xGrenze;
    private float zGrenze;
    private new Renderer renderer;

    public float getXGrenze()
    {
        return xGrenze;
    }

    public float getZGrenze()
    {
        return zGrenze;
    }
    
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

    private void Start()
    {
        renderer = plane.GetComponent<Renderer>();
        xGrenze = renderer.bounds.size.x / 2;
        zGrenze = renderer.bounds.size.z / 2;
    }
}
