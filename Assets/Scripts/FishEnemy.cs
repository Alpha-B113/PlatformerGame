using UnityEditor.Tilemaps;
using UnityEngine;

public class PiranhaJump : MonoBehaviour
{
    public float jumpPower = 5f;
    private float jumpInterval = 2f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        jumpInterval = Random.Range(1.5f, 2f);
        jumpPower = Random.Range(12f, 13f);
    }

    private void Start()
    {
        StartCoroutine(DoJumpLoop());
    }

    private void Update()
    {
        CheckVerticalDirection();
    }

    private void CheckVerticalDirection()
    {
        if (rb.linearVelocityY < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            sr.flipX = sr.flipY = true;
        }
        else if (rb.linearVelocityY > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            sr.flipX = sr.flipY = false;
        }
        else
        {
            sr.flipX = sr.flipY = false;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    System.Collections.IEnumerator DoJumpLoop()
    {
        while (true)
        {
            Jump();
            yield return new WaitForSeconds(jumpInterval);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gas"))
        {
            gameObject.SetActive(false);
        }
    }
}
