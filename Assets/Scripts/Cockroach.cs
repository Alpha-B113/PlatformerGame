using UnityEngine;

public class Cockroach : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gas"))
        {
            gameObject.SetActive(false);
        }
    }
}
