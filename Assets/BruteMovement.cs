using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMovement : MonoBehaviour
{
    public float moveSpeed = 3f;            // Speed for left-right movement
    public float jumpForce = 2f;            // Force applied for jumping
    public LayerMask groundLayer;           // Layer to define "ground"
    public Transform groundCheck;           // Position to check if player is on the ground
    public float groundCheckRadius = 0.2f;  // Radius for ground check
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze rotation in 2D
    }

    void Update()
    {

        // Move input from left/right arrows or "A" and "D" keys
        float moveInput = Input.GetAxisRaw("Horizontal");



        // Flip the sprite based on the movement direction
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;  // Face right (default direction)
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;   // Face left (flipped direction)
        }

            // Move the player horizontally
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jump if "W" or "Space" is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Jump
        }


            // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }
}
