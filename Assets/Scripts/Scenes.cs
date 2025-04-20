using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public string SceneName;
    private bool shouldMove = false;


    private void Update()
    {
        if (shouldMove && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shouldMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shouldMove = false;
        }
    }
}
