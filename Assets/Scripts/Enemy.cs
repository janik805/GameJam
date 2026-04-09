using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private WaveSpawner waveSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
        waveSpawner = GetComponentInParent<WaveSpawner>();
    }

    // Update is called once per frame
    public void Update()
    {
        Destroy(gameObject);
        waveSpawner.waves[waveSpawner.getCurrentWaveIndex()].enemiesLeft--;
    }
    
    public abstract void Walk();
}
