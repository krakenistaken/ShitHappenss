using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    public Collider meleeDamageZone;

    [SerializeField]
    public int MeleeDamage;

    private bool ReadyToMelee;
    private bool enemyInRange;

    public Health enemyHealth;
    
    void Start()
    {
        ReadyToMelee = true;
    }

    void Update()
    {

    }

    private void OnMelee()
    { 
        if(ReadyToMelee){

            animator.SetInteger("state", 1);
            Invoke("returnidle", 0.25f);
            Invoke("meleerestart", 1f);


            if (enemyInRange && ReadyToMelee)
            {
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(MeleeDamage);
                    ReadyToMelee = false;
                }
            }

            ReadyToMelee = false;
        }
    }

    void returnidle()
    {
        animator.SetInteger("state", 0);
    }
    
    void meleerestart()
    {
        ReadyToMelee = true;
    }


    
    void OnTriggerEnter(Collider meleeDamageZone)
    {
        enemyHealth = meleeDamageZone.gameObject.GetComponent<Health>();
    }

    private void OnTriggerStay(Collider meleeDamageZone)
    {
        enemyInRange = true;
    }

    private void OnTriggerExit(Collider meleeDamageZone)
    {
        enemyInRange = false;
        enemyHealth = null;
    }
}
