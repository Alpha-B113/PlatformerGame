using UnityEngine;
using UnityEngine.SceneManagement;

public class University : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("LoadMenu", 3f);
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
