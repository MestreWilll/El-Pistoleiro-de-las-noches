using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 // Mudar a class de acordo com o script 
 // rb2D não funciona
public class MoveChar2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontalInput, verticalInput).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
}
