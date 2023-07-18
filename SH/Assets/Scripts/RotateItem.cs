using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public Vector3 vector;    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(vector * Time.deltaTime);
    }
}
