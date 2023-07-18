using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtInput : MonoBehaviour
{
    private Vector2 RS;
    private Vector3 hitpoint;
    private float angle;
    public float rotationSpeed = 5.0f;
    public Collider playercollider;

    private void Update()
    {
        string[] joystickNames = Input.GetJoystickNames();

        if (joystickNames.Length > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle - 50, Vector3.down), Time.deltaTime * rotationSpeed);
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(hitpoint - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void OnLookatC(InputValue value)
    {
        RS = value.Get<Vector2>();

        Vector3 direction = new Vector3(RS.x, RS.y, 0f);
        if (direction.magnitude > 0.1f)
        {
            angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        }
    }
    

    void OnLookatM(InputValue value)
    {
        Ray ray = Camera.main.ScreenPointToRay(value.Get<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        if (hit.collider != playercollider){
        hitpoint = hit.point;
        hitpoint.y = transform.position.y;
        }

    }

}