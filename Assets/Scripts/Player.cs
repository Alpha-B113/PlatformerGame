using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movingSpeed = 5f;
    private Animator animator;
    private bool isRunning;
    private bool isGrounded;
    private bool isDied;
    private SpriteRenderer sr;
    private const string IsRunning = "IsRunning";
    private const string IsJumping = "IsJumping";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        isRunning = false;
        if (rb.linearVelocity == Vector2.zero)
        {
            SetGrounded();
        }

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        HorizontalMove();
    }

    private void HorizontalMove()
    {
        var horizontalMove = Input.GetAxis("Horizontal") * movingSpeed;

        if (horizontalMove > 0.1)
            sr.flipX = false;
        else if (horizontalMove < -0.1)
            sr.flipX = true;

        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocityY);
        isRunning = Mathf.Abs(horizontalMove) > 0.1 && isGrounded;
        animator.SetBool(IsRunning, isRunning);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * 10.5f, ForceMode2D.Impulse);
        rb.linearVelocityY = Math.Min(10.5f, rb.linearVelocityY);
        animator.SetBool(IsJumping, true);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            SetGrounded();
        }

        if (!isDied && collision.collider.CompareTag("Enemy"))
        {
            isDied = true;
            animator.SetTrigger("TouchEnemy");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (!isDied && collision.collider.CompareTag("CocroachEnemy"))
        {
            if (AppleCounter.appleCount == 0)
            {
                isDied = true;
                animator.SetTrigger("TouchEnemy");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                AppleCounter.appleCount--;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void SetGrounded()
    {
        animator.SetBool(IsJumping, false);
        isGrounded = true;
    }
}
