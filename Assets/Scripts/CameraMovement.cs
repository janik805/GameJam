using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 pos = new Vector3(0, 30, 0);
    // Rotate for Top-Down-View
    private Quaternion rotation = Quaternion.Euler(90, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = pos;
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
