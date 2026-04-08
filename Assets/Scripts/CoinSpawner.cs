using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    public GameObject plane;
    private float xGrenze;
    private float zGrenze;
    private Renderer renderer;

    void Start()
    {
        renderer = plane.GetComponent<Renderer>();
        xGrenze = renderer.bounds.size.x / 2;
        zGrenze = renderer.bounds.size.z / 2;
        InvokeRepeating(nameof(SpawnCoin), 1, 1);
    }

    public void SpawnCoin()
    {
        float spawnpointX = Random.Range(-xGrenze, xGrenze);
        float spawnpointZ = Random.Range(-zGrenze, zGrenze);

        Vector3 spawnPoint = new Vector3(spawnpointX, 1, spawnpointZ);
        Instantiate(Coin, spawnPoint, Quaternion.identity);
    }
}