using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject parent;
    public Wave[] waves;
    private int currentWaveIndex = 0;
    private bool readyToCountDown;

    void Start()
    {
        readyToCountDown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            return;
        }
        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }
        
        if (countdown <= 0)
        {
            readyToCountDown = false;
            countdown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }

        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
    }

    public int getCurrentWaveIndex()
    {
        return currentWaveIndex;
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            
            float xGrenze = WorldStatsManager.Instance.getXGrenze();
            float zGrenze = WorldStatsManager.Instance.getZGrenze();
        
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                float spawnpointX = Random.Range(-xGrenze, xGrenze);
                float spawnpointZ = Random.Range(-zGrenze, zGrenze);
                Vector3 spawnPoint = new Vector3(spawnpointX, 1, spawnpointZ);
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint, Quaternion.identity);
                enemy.transform.SetParent(parent.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }
}

[System.Serializable]
public class Wave
{
    
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;
    [HideInInspector] public int enemiesLeft;
}