using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BananaEnemy : MonoBehaviour
{
    private float fallAngle = 90f;
    private float rotationSpeed = 360f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FallAndRecover(other.transform));
        }
    }

    private IEnumerator FallAndRecover(Transform playerTransform)
    {
        Quaternion startRotation = playerTransform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 0, fallAngle);


        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * (rotationSpeed / 100f);
            playerTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsed);
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
