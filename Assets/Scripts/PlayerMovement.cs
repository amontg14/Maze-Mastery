using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PowerUp powerUp;
    public string currentPower;

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jetpackForce;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public int maxJumps = 0; // Maximum number of jumps allowed
    private int jumpsPerformed = 0; // Number of jumps performed
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("References")]
    public Transform orientation; // Reference to the player's orientation
    public Transform cameraTransform; // Reference to the third-person camera

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        powerUp = GetComponent<PowerUp>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        if (!GameManager.gameStarted)
            return;

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        currentPower = powerUp.power;
        if (grounded)
        {
            rb.drag = groundDrag;
            jumpsPerformed = 0; // Reset jumps when grounded
        }
        else
        {
            rb.drag = 0;
        }

        if (powerUp.doublejump)
        {
            maxJumps = 1;
        }
        else if (powerUp.jump)
        {
            maxJumps = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && powerUp.jetpack)
        {
            rb.AddForce(transform.up * jetpackForce, ForceMode.Force);
        }

        else if (Input.GetKeyDown(jumpKey) && readyToJump && (grounded || jumpsPerformed < maxJumps) && (powerUp.jump || powerUp.doublejump))
        {
            readyToJump = false;

            Jump();

            if (grounded)
            {
                jumpsPerformed = 1; // Reset jumps when grounded and jump is performed
            }
            else
            {
                jumpsPerformed++; // Increment jumps performed
            }

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // Get the forward and right direction relative to the camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Flatten the vectors on the xz plane
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculate the move direction relative to the camera
        moveDirection = forward * verticalInput + right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        jumpsPerformed++; // Increment jumps performed
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    // Apply downward force when colliding with a wall
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.AddForce(Vector3.down * moveSpeed, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("ClimbWall"))
        {
            rb.AddForce(Vector3.down * moveSpeed, ForceMode.Impulse);

            if (powerUp.climb)
            {
                jumpsPerformed = 0;
            }
        }
    }
}
