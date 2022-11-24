using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Entity
{
    NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float shootForce;

    [SerializeField] private GameObject health;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject ammo;

    [SerializeField] private Transform statsPosition;

    //Stats Bar
    [SerializeField] private StatsBar statsBar;

    //Patroling
    
    Vector3 WalkPoint;
    private bool WalkPointSet;
    [SerializeField] float WalkPointRange;

    //Atack

    [SerializeField] private float timeBetweenAtack;
    private bool alreadyAtack;

    //States

    [SerializeField] private float sightRange, attackRange;
     private bool playerInSightRange, playerInAttckRange;

    private void Awake()
    {
        player = GameObject.Find("FP_Character").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        statsBar.SetMaxHealth(_maxHealth);
        statsBar.SetMaxShield(_maxShield);
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttckRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttckRange) Patroling();
        if (playerInSightRange && !playerInAttckRange) ChasePlayer();
        if (playerInSightRange && playerInAttckRange) Attack();
    }

    private void Patroling()
    {
        if (!WalkPointSet) 
            SearchPoint();

        if (WalkPointSet)
            agent.SetDestination(WalkPoint);

        Vector3 distanceToWalkPoint = transform.position - WalkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            WalkPointSet = false;
    }

    private void SearchPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(WalkPoint, -transform.up, 2f, whatIsGround))
            WalkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        //Make sure enemy doesn`t move

        agent.SetDestination(transform.position);

        transform.LookAt(player.position);

        if (!alreadyAtack)
        {
            //Attack
            Rigidbody rb = Instantiate(bullet, attackPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

           /*if (bullet != null && rb != null)
            {
                Destroy(rb, 1f);
                Destroy(bullet, 1f);
            }
           */

            alreadyAtack = true;
            Invoke(nameof(ResetAttack), timeBetweenAtack);
        }
    }

    private void ResetAttack()
    {
        alreadyAtack = false;
    }

    override public void TakeDamage(float points)
    {
        if (_currentShield > 0)
        {
            _currentShield -= points;
        }
        else
        {
            _currentHealth -= points;

            if(_currentHealth <= 0) 
            {
                FindObjectOfType<AudioManager>().Play("Damage Enemy");
                Death();
            }
        }

        statsBar.SetHealth(_currentHealth);
        statsBar.SetShield(_currentShield);
    }

    private void SpawnStats()
    {
        int index = Random.Range(0, 2);

        switch (index)
        {
            case 0:
                if (gameObject != null)
                {
                    Instantiate(health, statsPosition.position, Quaternion.identity);
                }
                break;
            case 1:
                if (gameObject != null)
                {
                    Instantiate(shield, statsPosition.position, Quaternion.identity);
                }
                break;
            default:
                break;
        }
    }

    override protected void Death()
    {
        //animator.SetBool("Fall", true);
        if (gameObject != null)
        {
            SpawnStats();
            Destroy(gameObject , 0.1f);
        }
    }
}
