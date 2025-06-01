using UnityEngine;

public class RunningEnemy : MonoBehaviour
{
    public AudioSource ratSqueak;
    private Vector2 direction = new(-0.1f, 0);
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        rb.MovePosition(rb.position + direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBoundary"))
        {
            direction.x *= -1;
            sr.flipX ^= true;
            ratSqueak.Play();
        }
        else if (other.CompareTag("Gas"))
        {
            gameObject.SetActive(false);
            ratSqueak.Stop();
        }
    }
}
