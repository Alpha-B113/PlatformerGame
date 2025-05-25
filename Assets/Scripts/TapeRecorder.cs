using System.Collections;
using UnityEngine;

public class TapeRecorder : MonoBehaviour
{
    public GameObject Note;
    private SpriteRenderer noteSr;
    private BoxCollider2D noteCollider;

    public float riseSpeed = 3f;
    public float duration = 2f;



    private void Awake()
    {
        noteSr = Note.GetComponent<SpriteRenderer>();
        noteCollider = Note.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(SpawnSmoke());
    }

    private IEnumerator SpawnSmoke()
    {
        while (true)
        {
            StartCoroutine(MoveSmokeUp());
            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator MoveSmokeUp()
    {
        noteSr.enabled = true;
        noteCollider.enabled = true;

        var elapsed = 0f;
        var startPosition = transform.position;

        var amplitude = 0.3f;
        var frequency = 8f;

        while (elapsed < duration)
        {
            var yOffset = riseSpeed * elapsed;
            var xOffset = Mathf.Sin(elapsed * frequency) * amplitude;
            var newPosition = startPosition + new Vector3(xOffset, yOffset, 0);
            Note.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        HideSmoke();
    }


    private void HideSmoke()
    {
        Note.transform.position = transform.position;
        noteCollider.enabled = false;
        noteSr.enabled = false;
    }
}
