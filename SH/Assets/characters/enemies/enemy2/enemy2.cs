using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy2 : MonoBehaviour
{
    public float dropRate;
    public GameObject hpDrop, xpDrop;

    public Vector3 firstPos;
    public Vector3 Destination;
    public NavMeshAgent agent;
    public Transform player;
    public bool playerInFollowRange, playerInDashRange, destinationSet, readyToAttack, readyToDash, attacked;
    public float followRange, dashRange, patrolRange;
    public LayerMask whatIsPlayer;
    public Animator enemy2animator;
    public Rigidbody rb;
    public Health playerHP;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        firstPos = transform.position;
        readyToAttack = true;
        player = GameObject.Find("rockbud").transform;
    }

    private void Update()
    {
        playerInFollowRange = Physics.CheckSphere(transform.position, followRange, whatIsPlayer);
        playerInDashRange = Physics.CheckSphere(transform.position, dashRange, whatIsPlayer);

        if (!playerInFollowRange && !playerInDashRange) patroll();
        if (playerInFollowRange && !playerInDashRange && !attacked) followPlayer();
        if (playerInDashRange && playerInFollowRange && !attacked) dashPlayer();
        if (playerInFollowRange && attacked) holdPos();

    }
    void patroll()
    {
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
    }
    void followPlayer()
    {
        agent.speed = 5;
        enemy2animator.SetBool("walking", true);
        agent.SetDestination(player.position);
        transform.LookAt(player.position);
    }
    void dashPlayer()
    {
            agent.SetDestination(player.position);
            transform.LookAt(player.position);
            agent.speed = 15f;
            enemy2animator.SetBool("walking", true);
    }
    void holdPos()
    {
        agent.SetDestination(transform.position);
    }
    void dashreset()
    {
        agent.speed = 5f;
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") && !attacked)
        {
            playerHP = collision.collider.GetComponent<Health>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(20);
                attacked = true;
                Invoke("attackedReset", 1);
            }
        }
        
    }
    void attackedReset()
    {
        attacked = false;
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