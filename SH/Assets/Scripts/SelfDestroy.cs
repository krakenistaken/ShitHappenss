using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float destructionTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy",destructionTime);
    }


    private void Destroy()
    {
        Destroy(gameObject);
    }
}
