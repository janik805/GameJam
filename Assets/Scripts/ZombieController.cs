using UnityEngine;
using System.Collections;

public class ZombieController : Enemy
{
    private GameObject player;
    private new Rigidbody rigidbody;
    private Animator animation;
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private ParticleSystem getHitParticle;

    private bool contact;
    private bool isAlive;
    private float speed;
    private int damage = 10;
    private int healthPoints = 2;
    private float attackRange = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 35;
        isAlive = true;
        contact = false;
        animation = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Attack", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
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
        animation.SetTrigger("hit");
        getHitParticle.Play();
        healthPoints--;
        if (healthPoints <= 0) 
        {
            ZombieDeath();
        }
    }

    private void ZombieDeath() {
        isAlive = false;
        animation.SetBool("dead", true);
        StartCoroutine(WaitForZombieDeath());
        WaveDeathEvent();
    }

    IEnumerator WaitForZombieDeath() 
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
