using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    private float timer; 
    private float waitTime;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            SpawnEnemy();
            timer = 0;
            waitTime = Random.Range(1, 10);
        }
        
    }

    public void SpawnEnemy()
    {
        
        float xGrenze = WorldStatsManager.Instance.getXGrenze();
        float zGrenze = WorldStatsManager.Instance.getZGrenze();
        
        float spawnpointX = Random.Range(-xGrenze, xGrenze);
        float spawnpointZ = Random.Range(-zGrenze, zGrenze);

        Vector3 spawnPoint = new Vector3(spawnpointX, 1, spawnpointZ);
        Instantiate(Enemy,  spawnPoint, Quaternion.identity);
    }
}
