using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPushScript : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector2 pushDirection = Vector2.left;
    private Quaternion targetRotation = Quaternion.Euler(0, 0, 90);
    private Rigidbody2D playerRb;
    private Animator animator;
    private bool isTriggered;
    private bool isPlayerDodged;
    private float triggerTime;
    private float waitTime = 0.4f;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerRb = player.GetComponent<Rigidbody2D>();
        if (pushDirection == Vector2.left)
            targetRotation = Quaternion.Euler(0, 0, 90);
        else if (pushDirection == Vector2.right)
            targetRotation = Quaternion.Euler(0, 0, -90);

    }

    private void Update()
    {
        if (!player.isPushed && isTriggered && Time.time - triggerTime >= waitTime + 0.1f)
        {
            isPlayerDodged = true;
        }
        else if (!player.isPushed && isTriggered && Time.time - triggerTime >= waitTime)
        {
            animator.SetTrigger("isOpening");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTriggered && collision.collider.CompareTag("Player"))
        {
            isTriggered = true;
            triggerTime = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || player.isPushed || isPlayerDodged || !isTriggered)
            return;

        if (Time.time - triggerTime >= waitTime)
        {
            player.isPushed = true;
            animator.SetTrigger("isOpening");
            playerRb.AddForce(pushDirection * 10.5f, ForceMode2D.Impulse);
            StartCoroutine(Fall(player.transform));
        }
    }

    private IEnumerator Fall(Transform playerTransform)
    {
        var startRotation = playerTransform.rotation;
        var elapsed = 0f;

        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime * (360 / 100f);
            playerTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsed);
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
