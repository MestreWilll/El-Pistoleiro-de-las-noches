using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Consertado para não ir para cima
public class MoveChar2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0).normalized;
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }
}
