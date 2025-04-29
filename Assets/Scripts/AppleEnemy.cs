using UnityEngine;
using System.Collections.Generic;

public class appleEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] public List<GameObject> cocroaches = new List<GameObject>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            foreach (var cocroach in cocroaches)
            {
                cocroach.SetActive(true);
            }
        }
    }
}
