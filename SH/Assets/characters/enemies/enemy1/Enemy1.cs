using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    public float dropRate;
    public GameObject hpDrop, xpDrop;

    public Vector3 firstPos;
    public Vector3 Destination;
    public float patrolRange;
    public NavMeshAgent agent;
    public Transform player, bulletSpawner;
    public bool playerInSightRange, playerInAttackRange, destinationSet, readyToAttack;
    public float sightRange, attackRange;
    public LayerMask whatIsPlayer;
    public Animator enemy1animator;
    public GameObject projectile;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        firstPos = transform.position;
        readyToAttack = true;
        player = GameObject.Find("rockbud").transform;
        bulletSpawner = transform.GetChild(2);
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    //devriye
    void Patroling()
    {
        enemy1animator.SetFloat("AnimationChanger", 0);
        //devriye alan?nda random pozisyon seç
        if (!destinationSet)
        {
            float randomZ = Random.Range(-patrolRange, patrolRange);
            float randomX = Random.Range(-patrolRange, patrolRange);

            Destination = new Vector3(firstPos.x + randomX, firstPos.y, firstPos.z + randomZ);
            destinationSet = true;
            agent.SetDestination(Destination);
        }
        if (destinationSet) agent.SetDestination(Destination);

        Vector3 distanceToDestination = transform.position - Destination;

        if (distanceToDestination.magnitude < 1f)
            destinationSet = false;
    }//her frame yeni nokta seçip gitmeye çal??mas?n diye destinationset bool'u var

    void ChasePlayer()
    {
        enemy1animator.SetFloat("AnimationChanger", 0);
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (readyToAttack)
        {
            enemy1animator.SetFloat("AnimationChanger", 1);
            Invoke("shootProjectile", 0.2f);
            Invoke("resetAttack", 2f);
            readyToAttack = false;
        }
    }


    void resetAttack()
    {
        readyToAttack = true;
    }

    void shootProjectile()
    {
        var bullet = Instantiate(projectile, bulletSpawner.position, bulletSpawner.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawner.forward * 30f;
        readyToAttack = false;
        enemy1animator.SetFloat("AnimationChanger", 0);
    }

    private void OnDestroy()
    {
        if (Random.value < dropRate)
        {
            GameObject.Instantiate(hpDrop, transform.position, transform.rotation);
        }
        GameObject.Instantiate(xpDrop, transform.position, transform.rotation);
    }
}


