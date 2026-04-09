using UnityEngine;

public class ControlCoin : MonoBehaviour
{
    private const float RotationSpeed = 75;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * RotationSpeed));
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerStatsManager.Instance.GiveCoins(1);
            WorldStatsManager.Instance.decreaseCoinsSpawned();
            Destroy(gameObject);
        }
    }
}
