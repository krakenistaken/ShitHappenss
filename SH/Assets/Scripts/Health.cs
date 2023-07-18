using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Animator animator;
    public bool takingDMG;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(int damage)
    {
        takingDMG = true;

            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            animator.SetBool("takingDamage", true);
            Invoke("notTakingDamage", 0.5f);

        
    }

    public void heal(int healamount)
    {
        health += healamount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void notTakingDamage()
    {
        animator.SetBool("takingDamage", false);
        takingDMG = false;
    }

}