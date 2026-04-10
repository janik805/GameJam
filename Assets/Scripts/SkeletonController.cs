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
    [SerializeField] private ParticleSystem getHitParticle;
    private Boolean contact;
    private bool isAlive;
    private int damage = 5;
    private float attackRange = 3.5f;
    private int healthPoints = 1;

    private AudioSource sound;
    [SerializeField] private AudioClip punchSound;
    [SerializeField] private AudioClip deathSound;

    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {   
        base.Start();
        isAlive = true;
        contact = false;
        speed = 40;
        player = GameObject.FindWithTag("Player");
        animation = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Attack", 0f, 1f);
        sound = GetComponent<AudioSource>();
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
        } else {
            animation.SetFloat("speed", 0);
        }
    }

    public void Attack()
    {
        if (contact && isAlive)
        {
            animation.SetTrigger("attack");
            sound.clip = punchSound;
            sound.Play();
            StartCoroutine(WaitForSlashCoroutine());
        }
    }

    IEnumerator WaitForSlashCoroutine() 
    {
        yield return new WaitForSeconds(0.5f);
        PlayerStatsManager.Instance.TakeDamage(damage);
        hitParticle.Play();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Projectile") && other.gameObject.activeSelf) 
        {
            ReceiveDamage();
        }
    }

    private void ReceiveDamage() 
    {
        getHitParticle.Play();
        healthPoints--;
        if (healthPoints <= 0) 
        {
            SkeletonDeath();
        }
    }

    private void SkeletonDeath() {
        isAlive = false;
        animation.SetBool("dead", true);
        StartCoroutine(WaitForSkeletonDeath());
        WaveDeathEvent();
    }

    IEnumerator WaitForSkeletonDeath() 
    {
        yield return new WaitForSeconds(0.5f);
        sound.clip = deathSound;
        sound.Play();
        Destroy(gameObject, sound.clip.length);
    }
}
