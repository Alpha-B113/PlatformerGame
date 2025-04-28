using UnityEngine;

public class EagleEnemy : MonoBehaviour
{
    public Transform player;
    private SpriteRenderer sr;
    public float speed = 7f;

    private bool isTriggered = false;
    private float angle;
    private Vector3 direction;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isTriggered)
            transform.position += direction * 0.05f;
    }

    private void FlipEagle(float angle)
    {
        if (0 <= angle && angle <= 90)
            sr.flipY = false;
        else if (90 <= angle && angle <= 180)
            sr.flipY = true;
        else if (-90 <= angle && angle <= 0)
            sr.flipY = false;
        else
            sr.flipY = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            direction = (player.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            FlipEagle(angle);
        }
    }
}
