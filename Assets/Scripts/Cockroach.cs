using Unity.VisualScripting;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    public AudioSource turnSound;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!gameObject.IsDestroyed())
        {
            turnSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gas"))
        {
            gameObject.SetActive(false);
            turnSound.Stop();
        }
    }
}
