using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject plane;
    new Rigidbody rigidbody;
    private float horizontalInput;
    private float forwardInput;
    private int turnSpeed = 70;
    private int speed = 10;
    private float xGrenze;
    private float zGrenze;


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
        CheckLimit();
    }

    // Checks that player can't go out of Bounds
    private void CheckLimit()
    {
        if (plane!=null)
        {
            // Get edge of ground plane
            Renderer renderer = plane.GetComponent<Renderer>();
            xGrenze = renderer.bounds.size.x / 2;
            zGrenze = renderer.bounds.size.z / 2;

            if  (transform.position.x >= xGrenze)
            {
                transform.position = transform.position - new Vector3(1, 0 , 0);
            } else if  (Math.Abs(transform.position.x) >= xGrenze)
            {
                transform.position = transform.position + new Vector3(1, 0 , 0);
            }

            if  (transform.position.z >= zGrenze)
            {
                transform.position = transform.position - new Vector3(0, 0 , 1);
            } else if  (Math.Abs(transform.position.z) >= zGrenze)
            {
                transform.position = transform.position + new Vector3(0, 0 , 1);
            }
        }
    }
}
