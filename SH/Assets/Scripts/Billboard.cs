using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera Camera;
    private void Start()
    {
        Camera = Camera.main;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.transform.position);
        if ((Camera.transform.position - transform.position).magnitude < 10) { gameObject.SetActive(false); }
        else { gameObject.SetActive(true); }
    }
}
