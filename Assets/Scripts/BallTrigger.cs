using TMPro;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    [SerializeField] private BallKick ball;

    private bool isTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered && collision.CompareTag("Player"))
        {
            ball.Kick();
            isTriggered = true;
        }
    }
}
