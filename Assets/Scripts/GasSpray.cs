using TMPro;
using UnityEngine;

public class GasSpray : MonoBehaviour
{
    public PlayerAnimatorManager playerAnimatorManager;
    public TextMeshProUGUI gasCounterDisplay;
    public static int GasSprayCount;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        GasSprayCount = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        gasCounterDisplay.text = GasSprayCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GasSprayCount++;
            playerAnimatorManager.TryChangeController();
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }
}
