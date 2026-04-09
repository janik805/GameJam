using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    public GameObject plane;
    private float xGrenze;
    private float zGrenze;
    private new Renderer renderer;
    private float timer;
    private float waitTime;

    void Start()
    {
        renderer = plane.GetComponent<Renderer>();
        xGrenze = renderer.bounds.size.x / 2;
        zGrenze = renderer.bounds.size.z / 2;
    }

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
        if (WorldStatsManager.Instance.getCoinsSpawned() >= WorldStatsManager.Instance.getMaxCoinsSpawned()) return;
        float spawnpointX = Random.Range(-xGrenze, xGrenze);
        float spawnpointZ = Random.Range(-zGrenze, zGrenze);

        Vector3 spawnPoint = new Vector3(spawnpointX, 1, spawnpointZ);
        Instantiate(Coin, spawnPoint, Quaternion.identity);
        WorldStatsManager.Instance.increaseCoinsSpawned();
    }
}