using UnityEngine;

public class Cocroach : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gas"))
        {
            gameObject.SetActive(false);
        }
    }
}
