using UnityEngine;

public class BirdTrigger : MonoBehaviour
{
    public bool IsTriggered { get; private set; }
    public int attacksNumber;

    void Awake()
    {
        attacksNumber = Random.Range(2, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && attacksNumber > 0)
        {
            IsTriggered = true;
            attacksNumber--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            IsTriggered = false;
    }
}
