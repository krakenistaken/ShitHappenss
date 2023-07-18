using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Projectile : MonoBehaviour
{
    public Collider enemy1Collider;
    public Health playerHealth;
    private bool attacked;

    private void Start()
    {
        attacked = false;
        Invoke("destroyit", 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") && !attacked)
        {
            playerHealth = collision.collider.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(20);
                attacked = true;
                destroyit();
            }
        }
        destroyit();
    }
    
    void destroyit()
    {
        Destroy(gameObject);
    }
}
