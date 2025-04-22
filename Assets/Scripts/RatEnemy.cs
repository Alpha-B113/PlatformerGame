using UnityEngine;
using UnityEngine.UIElements;

public class Rat : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public Vector2 direction = new Vector2(-0.1f, 0);
    public float finishLeftX;
    public float finishRightX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.position.x <= finishLeftX)
        {
            direction.x *= -1;
            sr.flipX ^= true;
            rb.position = new Vector2(finishLeftX, rb.position.y);
        }
        else if (rb.position.x >= finishRightX)
        {
            direction.x *= -1;
            sr.flipX ^= true;
            rb.position = new Vector2(finishRightX, rb.position.y);
        }
        rb.MovePosition(rb.position + direction);
    }
}
