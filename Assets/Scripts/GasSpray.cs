using TMPro;
using UnityEngine;

public class GasSpray : MonoBehaviour
{
    public TextMeshProUGUI gasCounterDisplay;
    public static int GasSprayCount;
    private BoxCollider2D bc;
    private SpriteRenderer sr;


    private void Awake()
    {
        GasSprayCount = 0;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
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
            bc.enabled = false;
            sr.enabled = false;
        }
    }
}
