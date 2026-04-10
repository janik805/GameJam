using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject plane;
    public GameObject hitProjectile;
    new Rigidbody rigidbody;
    private Animator playerAnim;
    private float horizontalInput;
    private float forwardInput;
    private int speed = 35000;
    private float xGrenze;
    private float zGrenze;
    private Camera playerCam;
    private new Renderer renderer;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip punchSound;
    private AudioSource sound;
    private float time=0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        renderer = plane.GetComponent<Renderer>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        AnimatePlayer();
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << 0))
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

    void FixedUpdate() 
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rigidbody.AddForce(transform.right * (speed * horizontalInput), ForceMode.Force);
        rigidbody.AddForce(transform.forward * (speed * forwardInput), ForceMode.Force);
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
            AttackEnemy();
        }
        playerAnim.SetFloat("speed", forwardInput);
        playerAnim.SetFloat("horizontalSpeed", horizontalInput);
        sound.clip = walkSound;
        if (!sound.isPlaying)
        {
            if (forwardInput != 0 || horizontalInput != 0)
            {
                sound.Play();
                
            }
        }
    }

    private void AttackEnemy() 
    {
        if (time>0.5f)
        {
            playerAnim.SetTrigger("attacking");
            sound.PlayOneShot(punchSound);
            StartCoroutine(TriggerHitBox());
            time = 0;
        }
    }

    private IEnumerator TriggerHitBox() {
        hitProjectile.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitProjectile.SetActive(false);
    }
}