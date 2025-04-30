using UnityEngine;

public class BirdTrigger : MonoBehaviour
{
    public BirdEnemy Bird;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && Bird.attacksNumber > 0)
        {
            Bird.IsTriggered = true;
            Bird.attacksNumber--;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            Bird.IsTriggered = false;
    }
}
