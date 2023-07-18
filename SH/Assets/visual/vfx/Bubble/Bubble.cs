using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public LookAtInput lookatscript;
    public Rigidbody rb;
    public Transform Spawner;
    public Health enemyHealth;
    private bool attacked;
    private Vector3 forceVector;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        lookatscript = GameObject.Find("rockbud").GetComponent<LookAtInput>();
        rb = gameObject.GetComponent<Rigidbody>();
        Spawner = GameObject.Find("WaterBubbleSpawner").transform;

        attacked = false;
        Invoke("destroyit", 1f);
        forceVector = Spawner.forward;
    }

    private void Update()
    {
        rb.AddForce(forceVector * 10, ForceMode.Acceleration);

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("enemy") && !attacked)
        {
            enemyHealth = collision.collider.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                attacked = true;
                destroyit();
            }
        }
        
    }

    void destroyit()
    {
        Destroy(gameObject);
    }
}
