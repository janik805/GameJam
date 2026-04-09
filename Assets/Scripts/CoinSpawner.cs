using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    private float timer;
    private float waitTime;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            SpawnCoin();
            timer = 0;
            waitTime = Random.Range(1, 10);
        }
    }

    public void SpawnCoin()
    {
        float xGrenze = WorldStatsManager.Instance.getXGrenze();
        float zGrenze = WorldStatsManager.Instance.getZGrenze();
        
        if (WorldStatsManager.Instance.getCoinsSpawned() >= WorldStatsManager.Instance.getMaxCoinsSpawned()) return;
        float spawnpointX = Random.Range(-xGrenze, xGrenze);
        float spawnpointZ = Random.Range(-zGrenze, zGrenze);

        Vector3 spawnPoint = new Vector3(spawnpointX, 1, spawnpointZ);
        Instantiate(Coin, spawnPoint, Quaternion.identity);
        WorldStatsManager.Instance.increaseCoinsSpawned();
    }
}