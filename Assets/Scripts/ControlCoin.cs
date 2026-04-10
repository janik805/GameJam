using UnityEngine;

public class ControlCoin : MonoBehaviour
{
    public ParticleSystem particle;
    private const float RotationSpeed = 75;
    private AudioSource sound;
    [SerializeField] private AudioClip clip;

    void Start()
    {
        sound = GetComponent<AudioSource>();
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
            PlayerStatsManager.Instance.GiveCoins(1);
            WorldStatsManager.Instance.decreaseCoinsSpawned();
            particle.Play();
            particle.transform.parent = null;
            sound.clip = clip;
            sound.Play();
            
            Destroy(gameObject, clip.length);
        }
    }
}
