using TMPro;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    [SerializeField] private BallEnemy ball;

    private bool isTriggered;
    public AudioSource ballSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered && collision.CompareTag("Player"))
        {
            isTriggered = true;
            ball.Kick();
            ballSound.Play();
        }
    }
}
