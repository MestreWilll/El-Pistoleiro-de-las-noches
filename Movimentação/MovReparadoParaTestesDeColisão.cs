using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public int maxJumps = 2;
    private int remainingJumps;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingJumps = maxJumps;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)
        {
            Jump();
            remainingJumps--;
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0).normalized;
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
            remainingJumps = maxJumps;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }
}
////////////////Não esquecer de declara as layers, e interliga pra fazer a colisão