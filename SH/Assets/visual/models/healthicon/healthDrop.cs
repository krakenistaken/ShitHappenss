using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthDrop : MonoBehaviour
{
    public GameObject destroyeffect;
    public Health playerHP;
    public int healamount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            playerHP = other.GetComponent<Health>();
            playerHP.heal(healamount);
            GameObject.Instantiate(destroyeffect,transform.position, transform.rotation);
            
            gameObject.SetActive(false);
            
        }
    }
}
