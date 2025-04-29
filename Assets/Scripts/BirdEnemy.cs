using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public Transform Player;
    private SpriteRenderer sr;
    public float speed = 0.05f;
    public bool IsTriggered = false;
    private Vector3 direction;
    private float angle;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
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
        if (0 <= angle && angle <= 90)
            sr.flipY = false;
        else if (90 <= angle && angle <= 180)
            sr.flipY = true;
        else if (-90 <= angle && angle <= 0)
            sr.flipY = false;
        else
            sr.flipY = true;
    }
}
