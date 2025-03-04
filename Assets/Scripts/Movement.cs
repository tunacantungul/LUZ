using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 7f;
    private Rigidbody2D rb;
    private int jumpCount = 0;
    private const int maxJumps = 1;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator animator;
    private bool isGroundedd;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimatorParameters();
        if (Input.GetMouseButtonDown(button:0))
        {
            animator.Play("Power");
            
        }
    }
    
    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0)
        {
            animator.SetBool("Power", false);
            animator.SetBool("is Running", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            animator.SetBool("Power", false);
            animator.SetBool("is Running", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool("is Running", false);
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void HandleJump()
    {
        isGroundedd = IsGrounded();
        float moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && (jumpCount < maxJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            animator.Play("Jump");
            animator.SetBool("Power", false);
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
            animator.SetBool("isGrounded", false);
        }

        if (rb.velocity.y < 0 && !isGroundedd)
        {
            animator.SetBool("Power", false);
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }

        if (isGroundedd)
        {
            jumpCount = 0;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            animator.SetBool("isGrounded", true);
        }
    }

    void UpdateAnimatorParameters()
    {
        animator.SetBool("isGrounded", isGroundedd);
        //Debug.Log("Grounded: " + isGroundedd);
        //Debug.Log("VelocityY: " + rb.velocity.y);
    }

    private bool IsGrounded()
    {
        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return grounded;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
