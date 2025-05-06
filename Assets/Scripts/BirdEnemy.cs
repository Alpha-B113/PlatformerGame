using Unity.Mathematics.Geometry;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    // review: почему публичные поля, а не свойства?
    public Transform Player;
    public int attacksNumber; // перевести в подписку на события
    public bool IsTriggered = false;

    private SpriteRenderer sr;
    private float speed;
    private Vector3 direction;
    private float angle;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        attacksNumber = Random.Range(1, 5);
        speed = Random.Range(3.5f, 4.0f) / 100f;
    }

    void Update()
    {
        if (IsTriggered)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed);
            direction = (Player.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            FlipBird(angle);
        }
        else if (direction != null)
            transform.position += direction * speed;
    }

    private void FlipBird(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        sr.flipX = true;
        // review: sr.flipY = Math.Cos(angle * Math.PI / 180) < 0; не подойдет?
        // if (0 <= angle && angle <= 90)
        //     sr.flipY = false;
        // else if (90 <= angle && angle <= 180)
        //     sr.flipY = true;
        // else if (-90 <= angle && angle <= 0)
        //     sr.flipY = false;
        // else
        //     sr.flipY = true;
        sr.flipY = Mathf.Cos(angle * Mathf.PI / 180) < 0;
    }
}
