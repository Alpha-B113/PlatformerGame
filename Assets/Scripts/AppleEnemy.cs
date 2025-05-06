using UnityEngine;
using System.Collections.Generic;

public class appleEnemy : MonoBehaviour // review: имя класса же с заглавной буквы
{
    [SerializeField] public List<GameObject> cocroaches = new List<GameObject>();
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            foreach (var cocroach in cocroaches)
            {
                cocroach.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
