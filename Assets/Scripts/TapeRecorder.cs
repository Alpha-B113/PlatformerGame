using System.Collections;
using UnityEngine;

public class TapeRecorder : MonoBehaviour
{
    [Tooltip("Префаб ноты")]
    public GameObject NotePrefab;


    [Tooltip("Скорость подъёма ноты вверх")]
    private float riseSpeed = 3f;

    [Tooltip("Время жизни ноты в секундах")]
    private float duration = 3.5f;

    [Tooltip("Интервал между выпуском нот в секундах")]
    private float emissionInterval = 1.5f;

    private void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        while (true)
        {
            SpawnNote();
            yield return new WaitForSeconds(emissionInterval);
        }
    }

    private void SpawnNote()
    {
        // Определяем позицию появления
        Vector3 spawnPosition = transform.position;

        // Создаем новую ноту
        GameObject note = Instantiate(NotePrefab, spawnPosition, Quaternion.identity);

        // Запускаем корутину движения для этой ноты
        StartCoroutine(MoveNoteUp(note));
    }

    private IEnumerator MoveNoteUp(GameObject note)
    {
        SpriteRenderer sr = note.GetComponent<SpriteRenderer>();
        BoxCollider2D collider = note.GetComponent<BoxCollider2D>();

        if (sr != null) sr.enabled = true;
        if (collider != null) collider.enabled = true;

        float elapsed = 0f;
        Vector3 startPosition = note.transform.position;

        float amplitude = 0.3f;     // Размах колебаний влево-вправо
        float frequency = 8f;       // Частота покачивания

        while (elapsed < duration)
        {
            float yOffset = riseSpeed * elapsed;
            float xOffset = Mathf.Sin(elapsed * frequency) * amplitude;
            Vector3 newPosition = startPosition + new Vector3(xOffset, yOffset, 0);
            note.transform.position = newPosition;

            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(note);
    }
}