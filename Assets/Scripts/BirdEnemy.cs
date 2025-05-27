using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public Transform Player;
    public BirdTrigger Trigger;
    public AudioSource birdFlyingSound
        ;
    private SpriteRenderer spriteRenderer;
    private float speed;
    private Vector3 direction;
    private float angle;
    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = Random.Range(3.5f, 4.0f) / 100f;
    }

    void Update()
    {
        if (Trigger.IsTriggered)
        {
            birdFlyingSound.Play();
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed);
            direction = (Player.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            FlipBird(angle);
        }
        //else if (direction != null)
        else
            transform.position += direction * speed;
    }

    private void FlipBird(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        spriteRenderer.flipX = true;
        spriteRenderer.flipY = Mathf.Cos(angle * Mathf.PI / 180) < 0;
    }
}
