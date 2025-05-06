using UnityEngine;
using System.Collections.Generic;

// review: чем он норм?
public class NormAppleScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            AppleCounter.appleCount++;
        }
    }
}