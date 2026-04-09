using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject plane;
    new Rigidbody rigidbody;
    private Animator playerAnim;
    private float horizontalInput;
    private float forwardInput;
    private int speed = 200;
    private float xGrenze;
    private float zGrenze;
    private Camera playerCam;
    private new Renderer renderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        renderer = plane.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        AnimatePlayer();

        rigidbody.AddForce(transform.right * (speed * horizontalInput), ForceMode.Force);
        rigidbody.AddForce(transform.forward * (speed * forwardInput), ForceMode.Force);
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.Equals(plane))
            {
                Vector3 direction = hit.point - transform.position;
                direction.y = 0f;

                if (direction != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }
        CheckLimit();
    }

    // Checks that player can't go out of Bounds
    private void CheckLimit()
    {
        // Get edge of ground plane
        xGrenze = renderer.bounds.size.x / 2;
        zGrenze = renderer.bounds.size.z / 2;
        Vector3 playerPos = transform.position;
        // Checks if player is out of bounds on the x-Axis
        if (transform.position.x >= xGrenze)
        {   
            playerPos.x = xGrenze;
        }
        else if (Math.Abs(transform.position.x) >= xGrenze)
        {
            playerPos.x = -xGrenze;
        }

        // Checks  if player is out of bounds on the y-Axis
        if (transform.position.z >= zGrenze)
        {
            playerPos.z = zGrenze;
        }
        else if (Math.Abs(transform.position.z) >= zGrenze)
        {
            playerPos.z = -zGrenze;
        }

        transform.position = playerPos;
    }

    private void AnimatePlayer() 
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            playerAnim.SetTrigger("attacking");
        }
        playerAnim.SetFloat("speed", forwardInput);
        playerAnim.SetFloat("horizontalSpeed", horizontalInput);

    }
}