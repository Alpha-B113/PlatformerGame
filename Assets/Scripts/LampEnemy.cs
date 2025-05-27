using UnityEngine;

public class LampEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource fallingSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            fallingSound.Play();
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
