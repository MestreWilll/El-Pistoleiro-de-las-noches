using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public float checkDistance = 0.5f;

    private bool isGrounded;
    private bool jumpRequested;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            // Esta correndo
            animator.SetBool("Tacorrendo", true);
        } 
        else 
        {
            // Esta parado
            animator.SetBool("Tacorrendo", false);
        }

        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0).normalized;
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Turning
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        // Check if grounded
        Vector3 raycastOrigin = transform.position + new Vector3(0, -0.5f, 0);
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, checkDistance, groundLayer);
        isGrounded = hit.collider != null;

        // Request jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        // Apply jump force
        if (jumpRequested)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpRequested = false;
        }
    }
}