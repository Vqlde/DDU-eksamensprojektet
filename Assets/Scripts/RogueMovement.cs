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
    public bool isAlive = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze rotation in 2D
    }

    void Update()
    {

        float moveInput = Input.GetAxisRaw("Horizontal");



        if (moveInput > 0 && isAlive)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0 && isAlive)
        {
            spriteRenderer.flipX = true;
        }
        if (isAlive)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            if (isGrounded)
            {
                animator.SetFloat("speed", Mathf.Abs(moveInput * moveSpeed));
            }
        }

        if (isGrounded)
        {
            animator.SetBool("isJumping", !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer));
        }




        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) && isAlive) {
            if (isGrounded == true) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJumpAvailable = true;
                animator.SetBool("isJumping", !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer));
            } else {
                if (doubleJumpAvailable == true) {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    // double jump anim her
                    doubleJumpAvailable = false;
                }
            }


            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);



    }
}
