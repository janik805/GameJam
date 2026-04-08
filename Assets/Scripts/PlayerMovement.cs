using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody rigidbody;
    private float horizontalInput;
    private float forwardInput;
    private int turnSpeed = 70;
    private int speed = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rigidbody.AddForce(-1 * transform.right * speed * forwardInput, ForceMode.Impulse);
        if (forwardInput < 0)
        {
            transform.Rotate(Vector3.down, Time.deltaTime * turnSpeed * horizontalInput);
        } else {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }
}
