using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : Spawner
{

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
    }

    override 
    public void Spawn()
    {
        float xGrenze = WorldStatsManager.Instance.getXGrenze();
        float zGrenze = WorldStatsManager.Instance.getZGrenze();
        
        if (WorldStatsManager.Instance.getCoinsSpawned() >= WorldStatsManager.Instance.getMaxCoinsSpawned()) return;
        float spawnpointX = Random.Range(-xGrenze, xGrenze);
        float spawnpointZ = Random.Range(-zGrenze, zGrenze);

        Vector3 spawnPoint = new Vector3(spawnpointX, 1, spawnpointZ);
        Instantiate(GetObjectToSpawn(), spawnPoint, Quaternion.identity);
        WorldStatsManager.Instance.increaseCoinsSpawned();
    }
}