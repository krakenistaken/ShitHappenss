using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy3 : MonoBehaviour
{
    public float dropRate;
    public GameObject hpDrop, xpDrop;

    bool playerInFollowRange;
    bool playerInAttackRange;
    bool destinationSet;
    bool attacked;

    public float patrolRange;
    public float attackRange;
    public float FollowRange;
    public Health playerHP;
    public NavMeshAgent agent;
    public Animator enemy3animator;
    public LayerMask whatIsPlayer;
    public Transform Player;
    public Transform firstPos;
    Vector3 Destination;

    void Start()
    {
        firstPos = transform;
        Player = GameObject.Find("rockbud").transform;
    }

    void Update()
    {
        playerInFollowRange = Physics.CheckSphere(transform.position, FollowRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInFollowRange && !playerInAttackRange) chasePlayer();
        if (playerInFollowRange && playerInAttackRange) spinAttack();
        if (!playerInFollowRange && !playerInAttackRange) patroll();    
                
    }
    void patroll()
    {
        agent.speed = 3f;
        enemy3animator.SetBool("attacking", false);
        
        //devriye alan?nda random pozisyon seç
        if (!destinationSet)
        {
            float randomZ = Random.Range(-patrolRange, patrolRange);
            float randomX = Random.Range(-patrolRange, patrolRange);
            
            Destination = new Vector3(firstPos.position.x + randomX, firstPos.position.y, firstPos.position.z + randomZ);
            destinationSet = true;
            agent.SetDestination(Destination);
        }
        if (destinationSet) agent.SetDestination(Destination);

        Vector3 distanceToDestination = transform.position - Destination;

        if (distanceToDestination.magnitude < 1f)
            destinationSet = false;
    }
    void chasePlayer()
    {
        agent.speed = 3f;
        agent.SetDestination(Player.position);
    }

    void spinAttack()
    {
        enemy3animator.SetBool("attacking", true);
        agent.speed = 7f;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !attacked)
        {
            Health playerHP = other.GetComponent<Health>();

            if (playerHP != null)
            {
                playerHP.TakeDamage(20);
            }

            attacked = true;

            Invoke("attackedReset", 1);
        }
    }
    void attackedReset() { 
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


