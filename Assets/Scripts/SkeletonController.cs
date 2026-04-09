using UnityEngine;

public class SkeletonController : MonoBehaviour, EnemyInterface
{
    private GameObject player;
    private Animator animation;
    private new Rigidbody rigidbody;

    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 25;
        player = GameObject.FindWithTag("Player");
        animation = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Walk();
    }

    public void Walk() 
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 goToPlayer = (playerPosition - transform.position).normalized;
        rigidbody.AddForce(goToPlayer * speed);
        transform.rotation = Quaternion.LookRotation(goToPlayer);
        animation.SetFloat("speed", 1);
    }
}
