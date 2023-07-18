using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialougeStarterScript : MonoBehaviour
{
    public GameObject dialougeCanvas;
    public GameObject watereStone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("f") || Input.GetKeyDown("joystick button 0"))
        {
            dialougeCanvas.SetActive(true);
            watereStone.SetActive(false);
        }
    }
}
