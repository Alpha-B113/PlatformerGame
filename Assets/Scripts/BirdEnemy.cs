using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public Transform Player;
    public BirdTrigger Trigger;
    public AudioSource birdFlyingSound;
    private SpriteRenderer spriteRenderer;
    private float speed;
    private Vector3 direction;
    private float angle;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = 7;
    }

    void Update()
    {
        if (Trigger.IsTriggered)
        {
            if (!birdFlyingSound.isPlaying)
                birdFlyingSound.Play();
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            direction = (Player.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            FlipBird(angle);
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        if (Trigger.attacksNumber == 0)
            birdFlyingSound.Stop();
    }

    private void FlipBird(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        spriteRenderer.flipX = true;
        spriteRenderer.flipY = Mathf.Cos(angle * Mathf.PI / 180) < 0;
    }
}
