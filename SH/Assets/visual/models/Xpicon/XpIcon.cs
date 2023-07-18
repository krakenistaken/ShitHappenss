using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpIcon : MonoBehaviour
{
    public Vector3 rotation;
    public GameObject destroyeffect;
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
        if (other.CompareTag("Player"))
        {
            
            GameObject.Instantiate(destroyeffect, transform.position, Quaternion.Euler(rotation));

            gameObject.SetActive(false);

        }
    }
}
