
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject playerCamera;
    public Rigidbody playerRB;

    private Vector2 inputMoveDirection;
    private Vector3 relativeMoveDirection;
    private Vector3 accDir;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;

    [Header("dashing")]
    public float dashDistance = 5f;
    public float dashTime = 0.25f;
    public float dashCooldown = 1f;

    public bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;


    void Start()
    {
    }

    private void FixedUpdate()
    {

        // Kamera'n?n dönü? aç?s?n? kullanarak karakterin yönünü ayarlay?n
        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
        relativeMoveDirection = cameraForward * inputMoveDirection.y + cameraRight * inputMoveDirection.x;

        // Yaln?zca x ve z yönlerinde hareket edin
        relativeMoveDirection.y = 0f;
        if (!isDashing)
        {
            if (OnSlope())
            {
                playerRB.AddForce(GetSlopeMoveDirection() * speed, ForceMode.Force);
            }
            else playerRB.AddForce(relativeMoveDirection * speed, ForceMode.Force);
        }

        //dash
        if (dashCooldownTimer <= 0f)
        {
            dashCooldownTimer = 0f;
        }

        if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        if (isDashing)
        {
            dashTimer += Time.deltaTime;

            // If the dash time has expired, stop the dash
            if (dashTimer >= dashTime)
            {
                isDashing = false;

                // Start the dash cooldown
                dashCooldownTimer = dashCooldown;
            }
        }

    }

    private void OnMove(InputValue value)
    {
        inputMoveDirection = value.Get<Vector2>();

        if (inputMoveDirection == Vector2.zero)
        {
            playerRB.velocity = Vector3.zero;
        }

    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1f * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(relativeMoveDirection, slopeHit.normal).normalized;
    }


    public void asd()
    {
        Debug.Log("asd");
    }

    void OnDash()
    {
        if (dashCooldownTimer <= 0f && !isDashing)
        {

            Vector3 dashVector = relativeMoveDirection * dashDistance;

            // Start the dash
            isDashing = true;
            dashTimer = 0f;

            // Move the character with a rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(dashVector, ForceMode.Impulse);
            Invoke("stopPlayer", dashTime);
        }

    }

    void stopPlayer()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }
}




