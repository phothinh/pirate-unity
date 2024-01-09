using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    public float moveSpeed;
    private bool isFacingRight = false;
    public float jumpPower;
    private bool isGrounded = false;
    private bool hasTouchedTreasure = false;

    public int playerIndex;
    public bool isControlled = false;
    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isControlled)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            FlipSprite();

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                isGrounded = false;
                animator.SetBool("isJumping", !isGrounded);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isControlled)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
            animator.SetFloat("yVelocity", rb.velocity.y);
        }
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform") || collision.CompareTag("Box"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", !isGrounded);
        } 
        else if(collision.CompareTag("Key"))
        {
            collision.gameObject.SetActive(false);
            TreasureEventHandler.OnKeyCollected.Invoke();
        } 
        else if (collision.CompareTag("Chest") && !hasTouchedTreasure)
        {
            hasTouchedTreasure = true;
            TreasureEventHandler.OnPlayerTouch.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest") && hasTouchedTreasure)
        {
            hasTouchedTreasure = false;
            TreasureEventHandler.OnPlayerLeave.Invoke();
        }
    }

}
