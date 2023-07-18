using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class electricSpell : MonoBehaviour
{
    public int damage;
    public GameObject electric;
    public GameObject[] enemies;
    public float range;
    public Transform closestEnemyT; 
    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;
    public Transform Pos4;
    public Transform Player;

    Health enemyhealth;
    bool newonespawned;
    
    private void Start()
    {
        newonespawned = false;
    }
    private void Update()
    {
        Pos1.position = transform.position;
        Pos4.position = getClosestEnemy().position;
    }

    public Transform getClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        float ClosestDist = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject enemy in enemies)
        {
            float distance;
            enemyhealth = enemy.GetComponent<Health>();
            distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < ClosestDist && distance < range && distance > 0.001f && !enemyhealth.takingDMG)
            {
                ClosestDist = distance;
                trans = enemy.transform;
                enemyhealth.TakeDamage(damage);
                if (!newonespawned)
                {
                    Instantiate(electric, enemy.transform.position, Quaternion.identity);
                    newonespawned = true;
                }
            }
            
        }
        return trans; 
    }




}
