using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    private SpriteRenderer sr;
    public float speed = 3f; // Скорость движения птицы

    private bool isChasing = false; // Флаг, указывающий, преследует ли птица игрока

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            FlipBird(angle);
        }
        else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            sr.flipX = false;
        }
    }

    private void FlipBird(float angle)
    {
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

    private void FlipSprite(Vector2 direction)
    {
        // Если направление движения влево, делаем масштаб по оси X отрицательным
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Если направление движения вправо, делаем масштаб по оси X положительным
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, вошел ли игрок в зону обнаружения
        if (other.CompareTag("Player"))
        {
            isChasing = true; // Начинаем преследование
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Если игрок покинул зону обнаружения
        if (other.CompareTag("Player"))
        {
            isChasing = false; // Останавливаем преследование
        }
    }
}