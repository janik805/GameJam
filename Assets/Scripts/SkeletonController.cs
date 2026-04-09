using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    private GameObject player;
    private Animator animation;
    private Rigidbody rigidbody;

    private float speed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Vector3 playerPosition = player.transform.position;
        Vector3 goToPlayer = (playerPosition - transform.position).normalized;
        rigidbody.AddForce(goToPlayer * speed);
    }
}
