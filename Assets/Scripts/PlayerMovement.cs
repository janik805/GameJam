using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody rigidbody;
    private float horizontalInput;
    private float forwardInput;
    private int turnSpeed = 35;


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
        rigidbody.AddForce(Vector3.forward * forwardInput, ForceMode.Impulse);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
