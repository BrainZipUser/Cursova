using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    //[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

    [SerializeField] private Animator animator;
    [SerializeField] private float attackDistance = 3f;
    [SerializeField] private float movementSpeed = 4f;

    //How much damage will npc deal to the player
    [SerializeField] private float npcDamage = 5;
    [SerializeField] private float attackRate = 0.5f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject npcDeadPrefab;

    [HideInInspector]
    public Transform playerTransform;
    [HideInInspector]
    public SC_EnemySpawner es;
    UnityEngine.AI.NavMeshAgent agent;
    float nextAttackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.stoppingDistance = attackDistance;
        agent.speed = movementSpeed;

        //Set Rigidbody to Kinematic to prevent hit register bug
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance - attackDistance < 0.01f)
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;

                //Attack
                RaycastHit hit;
                if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, attackDistance))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * attackDistance, Color.cyan);

                        FP_Character player = hit.transform.GetComponent<FP_Character>();
                        player.TakeDamage(npcDamage);
                    }
                }
            }
        }
        //Move towardst he player
        agent.destination = playerTransform.position;
        //Always look at player
        transform.LookAt(new Vector3(playerTransform.transform.position.x, transform.position.y, playerTransform.position.z));
    }

    override public void TakeDamage(float points)
    {
        _currentHealth -= points;
        if (_currentHealth <= 0)
        {
            //Destroy the NPC
            GameObject npcDead = Instantiate(npcDeadPrefab, transform.position, transform.rotation);
            //Slightly bounce the npc dead prefab up
            npcDead.GetComponent<Rigidbody>().velocity = (-(playerTransform.position - transform.position).normalized * 8) + new Vector3(0, 5, 0);
            Destroy(npcDead, 10);
            //es.EnemyEliminated(this);
            Destroy(gameObject);
        }
    }

    override protected void Death() 
    {
        animator.SetBool("Fall", true);
        Destroy(gameObject, 3f);
    }
}
