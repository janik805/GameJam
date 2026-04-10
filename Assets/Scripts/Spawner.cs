using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    
    [SerializeField] private GameObject objectToSpawn;
    private float timer;
    private float waitTime;
    [SerializeField] private int initialSpawnNumber;
    [SerializeField] private int initialSpawnTime;
    private bool run;
    
    public void Start()
    {
        Invoke(nameof(InitialSpawn), initialSpawnTime);
        
    }

    // Update is called once per frame
    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime && run)
        {
            Spawn();
            timer = 0;
            waitTime = Random.Range(1, 10);
        }
    }
    
    public abstract void Spawn();

    private void InitialSpawn()
    {
        
        for (var i = 0; i < initialSpawnNumber; i++)
        {
            Spawn();
        }
        run = true;
    }
    
    public GameObject GetObjectToSpawn()
    {
        return objectToSpawn;
    }
}
