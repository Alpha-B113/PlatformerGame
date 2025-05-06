using UnityEngine;

public class BirdTrigger : MonoBehaviour
{
    public bool IsTriggered { get; private set; }
    private int attacksNumber;

    void Awake()
    {
        attacksNumber = Random.Range(1, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && attacksNumber > 0)
        {
            IsTriggered = true;
            attacksNumber--;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            IsTriggered = false;
    }
}
