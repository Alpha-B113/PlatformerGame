using UnityEngine;

// review: есть такое ощущение, что не совсем корректно спроектировано. Разве не было бы лучше, чтобы этот класс
// только предоставлял событие, а BirdEnemy уже бы на него подписывалось?
public class BirdTrigger : MonoBehaviour
{
    public BirdEnemy Bird { get; set; } // review: почему не свойство?

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
