using UnityEngine;

public class Cocroach : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    // review: это как будто бы лучше было сделать событием, а AppleCounter уже внутри себя бы изменял состояние
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (AppleCounter.appleCount != 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
