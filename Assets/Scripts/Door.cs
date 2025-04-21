using UnityEngine;

public class Door : MonoBehaviour
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


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isClosing", true);
            animator.SetBool("isOpening", false);
        }
    }
}
