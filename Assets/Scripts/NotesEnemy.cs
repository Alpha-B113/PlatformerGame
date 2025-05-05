using System.Collections;
using UnityEngine;

public class SimpleMusicNoteSpawner : MonoBehaviour
{
    [Tooltip("Префаб музыкальной ноты")]
    [SerializeField] private GameObject musicNotePrefab;

    [Tooltip("Интервал между выпуском нот (в секундах)")]
    [SerializeField] private float spawnInterval = 1.5f;

    [Tooltip("Скорость полёта ноты")]
    [SerializeField] private float noteSpeed = 3f;

    [Tooltip("Сила, с которой нота отбрасывает игрока")]
    [SerializeField] private float knockbackForce = 5f;

    void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        while (true)
        {
            // Создаём ноту справа от магнитофона
            Vector3 spawnPos = transform.position + new Vector3(0.5f, 0, 0);
            GameObject note = Instantiate(musicNotePrefab, spawnPos, Quaternion.identity);

            // Запускаем корутину для управления движением
            StartCoroutine(MoveNote(note, noteSpeed, knockbackForce));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator MoveNote(GameObject note, float speed, float force)
    {
        Rigidbody2D noteRb = note.GetComponent<Rigidbody2D>();
        noteRb.linearVelocity = transform.right * speed;

        while (true)
        {
            // Проверяем все пересечения с игроком
            Collider2D[] hits = Physics2D.OverlapCircleAll(note.transform.position, 0.5f);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("Player"))
                {

                    Destroy(note);
                    yield break;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.AddForce(transform.right * knockbackForce, ForceMode2D.Impulse);
            }

            // Уничтожаем ноту после контакта
            Destroy(other.gameObject);
        }
    }
}