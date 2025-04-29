using UnityEngine;
using UnityEngine.UIElements;

public class StudentEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Vector2 direction = new Vector2(-0.1f, 0);
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.MovePosition(rb.position + direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBoundary"))
        {
            direction.x *= -1;
            sr.flipX ^= true;
        }
    }
}
