using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    public bool IsTriggeredToShow;
    public bool IsTriggeredToHide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsTriggeredToShow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsTriggeredToHide = true;
        }
    }
}
