using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    protected bool IsOpened;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTrigger(Collider2D other, string trueEvent, string falseEvent)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool(falseEvent, false);
            animator.SetBool(trueEvent, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigger(other, "isOpening", "isClosing");
        IsOpened = true;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        OnTrigger(other, "isClosing", "isOpening");
        IsOpened = false;
    }
}
