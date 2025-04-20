using UnityEngine;

public class DoorEnemy : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isClosing", false);
            animator.SetBool("isOpening", true);
        }
    }
}
