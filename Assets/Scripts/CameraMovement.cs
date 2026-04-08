using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 10, 0);
    // Rotate for Top-Down-View
    private Quaternion rotation = Quaternion.Euler(90, 0, 0);
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
