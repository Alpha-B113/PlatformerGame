using UnityEngine;

public class ScooterTrigger : MonoBehaviour
{

    public bool IsTriggered { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsTriggered = true;
        }
    }
}
