using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float movingSpeed = 5f;
    private Animator animator;
    private bool isRunning;
    private bool isGrounded;
    private bool isDied;
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
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            animator.SetBool(IS_JUMPING, true);
            isGrounded = false;
        }

        var horizontalMove = Input.GetAxis("Horizontal") * movingSpeed;

        if (horizontalMove > 0.1)
            sr.flipX = true;
        else if (horizontalMove < -0.1)
            sr.flipX = false;

        isRunning = Mathf.Abs(horizontalMove) > 0.1 && isGrounded;

        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocityY);

        animator.SetBool(IS_RUNNING, isRunning);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool(IS_JUMPING, false);
            isGrounded = true;
        }

        if (!isDied && collision.collider.CompareTag("Enemy"))
        {
            isDied = true;
            animator.SetTrigger("TouchEnemy");
            ReloadSceneWithDelay(0.7f);
        }

    }

    public void ReloadSceneWithDelay(float delayInSeconds)
    {
        StartCoroutine(ReloadSceneCoroutine(delayInSeconds));
    }

    private IEnumerator ReloadSceneCoroutine(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
