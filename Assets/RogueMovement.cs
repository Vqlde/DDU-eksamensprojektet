using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Speed for left-right movement
    public float jumpForce = 5f;            // Force applied for jumping
    public LayerMask groundLayer;           // Layer to define "ground"
    public Transform groundCheck;           // Position to check if player is on the ground
    public float groundCheckRadius = 0.2f;  // Radius for ground check
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator animator;
    private bool doubleJumpAvailable;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze rotation in 2D
    }

    void Update()
    {

        float moveInput = Input.GetAxisRaw("Horizontal");



        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveInput * moveSpeed));

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded == true) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJumpAvailable = true;
            } else {
                if (doubleJumpAvailable == true) {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    doubleJumpAvailable = false;
                }
            }


            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


    }
}
