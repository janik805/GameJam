using UnityEngine;

public class ControlCoin : MonoBehaviour
{
    private const float RotationSpeed = 75;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * RotationSpeed));
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            StatsManager.Instance.GiveCoins(1);
            Destroy(gameObject);
        }
    }
}
