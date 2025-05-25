using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTrigger : MonoBehaviour
{
    public string SceneName;
    private bool isTriggered = false;

    private void Update()
    {
        if (isTriggered && (SceneName == "Dungeons" || Input.GetKeyDown(KeyCode.E)))
        {
            Player.StartPosition = Vector3.zero;
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }
}
