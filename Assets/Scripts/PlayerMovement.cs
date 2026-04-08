using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody rigidbody;
    private float horizontalInput;
    private float forwardInput;
    private int turnSpeed = 70;
    private int speed = 10;
    private Camera playerCam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rigidbody.AddForce(transform.right * (speed * horizontalInput), ForceMode.Force);
        rigidbody.AddForce(transform.forward * (speed * forwardInput), ForceMode.Force);
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.name == "Plane")
            {
                Vector3 direction = hit.point - transform.position;
                direction.y = 0f;

                if (direction != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }
    }
}