using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody rigidbody;
    private float horizontalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(Vector3.forward * horizontalInput, ForceMode.Impulse);
    }
}
