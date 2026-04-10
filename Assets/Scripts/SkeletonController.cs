using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonController : Enemy
{
    private GameObject player;
    private new Animator animation;
    private new Rigidbody rigidbody;
    [SerializeField] private ParticleSystem hitParticle;
    private Boolean contact;
    private int damage = 5;
    private float attackRange = 2.5f;

    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {   
        base.Start();
        contact = false;
        speed = 25;
        player = GameObject.FindWithTag("Player");
        animation = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Attack", 0f, 1f);
    }
    // Update is called once per frame
    new void Update()
    {
        contact = Vector3.Distance(player.transform.position, transform.position) < attackRange;
    }

    void FixedUpdate()
    {
        Walk();
    }

    override 
    public void Walk() 
    {
        Vector3 playerPosition = player.transform.position;
        float distance = Vector3.Distance(playerPosition, transform.position);
        if (distance < WorldStatsManager.Instance.getMinDistance())
        {
            Vector3 goToPlayer = (playerPosition - transform.position).normalized;
            rigidbody.AddForce(goToPlayer * speed);
            transform.rotation = Quaternion.LookRotation(goToPlayer);
            animation.SetFloat("speed", 1);
        }
    }

    public void Attack()
    {
        if (contact)
        {
            animation.SetTrigger("attack");
            StartCoroutine(WaitForSlashCoroutine());
        }
    }

    IEnumerator WaitForSlashCoroutine() 
    {
        yield return new WaitForSeconds(0.5f);
        PlayerStatsManager.Instance.TakeDamage(damage);
        hitParticle.Play();
    }
}
