using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshtraySmoke : MonoBehaviour
{
    public Health enemyHealth;
    private bool readyToAttack;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        readyToAttack = true;
        Invoke("destroyit", 6f);
    }

    /*
    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.CompareTag("enemy") && readyToAttack)
        {
            Invoke("attackreseter", 2f);
            enemyHealth = collision.GetComponent<Health>();
            
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20);
                readyToAttack = false;   
            }
        }

    }
    */

    private void OnTriggerStay(Collider collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 7);
        if (readyToAttack)
        {
            foreach (Collider collider in colliders)
            {

                Health enemyHealth = collider.GetComponent<Health>();

                if (enemyHealth != null && collision.gameObject.CompareTag("enemy"))
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
            readyToAttack = false;
            Invoke("attackreseter", 2f);
        }
    }



    void destroyit()
    {
        Destroy(gameObject);
    }

    void attackreseter()
    {
        readyToAttack = true ;
    }
}
