using UnityEngine;

public class EagleTrigger : MonoBehaviour
{
    public BirdEnemy Eagle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            Eagle.IsTriggered = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            Eagle.IsTriggered = false;
    }
}
