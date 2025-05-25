using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public bool LooksLeft => sr.flipX;
    public bool LooksRight => !sr.flipX;
    [FormerlySerializedAs("IsPushed")] public bool isPushed;
    public static Vector3 StartPosition;
    private Rigidbody2D rb;
    private float movingSpeed = 5f;
    private Animator animator;
    private bool isRunning;
    private bool isGrounded;
    private bool isDied;
    private SpriteRenderer sr;
    private const string IsRunning = "IsRunning";
    private const string IsJumping = "IsJumping";
    private float rayDistance = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (StartPosition != Vector3.zero)
            transform.position = StartPosition;
    }

    private void Update()
    {
        if (isPushed)
            return;

        isRunning = false;
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

        isGrounded = IsGrounded();
        if (isGrounded)
            animator.SetBool(IsJumping, false);
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
        if (!isDied && collision.collider.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private bool IsGrounded()
    {
        var position = rb.position;
        var raycasts = new Vector2[]
        {
            position,
            position + new Vector2(-0.3f, 0),
            position + new Vector2(0.3f, 0)
        };

        foreach (var point in raycasts)
        {
            var hit = Physics2D.Raycast(point, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
            if (hit.collider is not null)
                return true;
        }
        return false;
    }
}
