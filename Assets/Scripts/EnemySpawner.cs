using UnityEngine;

public class EnemySpawner : Spawner
{
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    override 
    public void Spawn()
    {
        
        float xGrenze = WorldStatsManager.Instance.getXGrenze();
        float zGrenze = WorldStatsManager.Instance.getZGrenze();
        
        float spawnpointX = Random.Range(-xGrenze, xGrenze);
        float spawnpointZ = Random.Range(-zGrenze, zGrenze);

        Vector3 spawnPoint = new Vector3(spawnpointX, 0.1f, spawnpointZ);
        Instantiate(GetObjectToSpawn(),  spawnPoint, Quaternion.identity);
    }
}
