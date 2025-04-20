using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float movingSpeed = 5f;
    private Animator animator;
    private bool isRunning;
    private bool isGrounded;
    private SpriteRenderer sr;
    private const string IS_RUNNING = "IsRunning";
    private const string IS_JUMPING = "IsJumping";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        isRunning = false;
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }

        var horizontalMove = Input.GetAxis("Horizontal") * movingSpeed;

        if (horizontalMove > 0.1)
            sr.flipX = true;
        else if (horizontalMove < -0.1)
            sr.flipX = false;

        isRunning = Mathf.Abs(horizontalMove) > 0.1 && isGrounded;

        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocityY);

        animator.SetBool(IS_RUNNING, isRunning);
        animator.SetBool(IS_JUMPING, !isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
        if (collision.collider.CompareTag("Enemy"))
            animator.SetTrigger("TouchEnemy");

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}
