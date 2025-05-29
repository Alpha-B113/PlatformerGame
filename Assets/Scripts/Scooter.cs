using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Scooter : MonoBehaviour
{
    public Vector2 Direction = new(-0.15f, 0);
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer[] srs;
    public ScooterTrigger Trigger;

    private void Awake()
    {
        srs = GetComponentsInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        rb.simulated = false;
        bc.enabled = false;
        foreach (var sr in srs)
            sr.enabled = false;

    }

    private void Update()
    {
        if (Trigger.IsTriggered)
        {
            foreach (var sr in srs)
                sr.enabled = true;
            rb.simulated = true;
            bc.enabled = true;
            Move();
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + Direction);
    }
}
