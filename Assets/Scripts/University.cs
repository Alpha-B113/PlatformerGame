using UnityEngine;
using UnityEngine.SceneManagement;

public class University : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadMenu();
        }
    }

    private void LoadMenu()
    {
        if (PauseMenu.Instance != null)
            PauseMenu.Instance.LoadMenu();
        else
            SceneManager.LoadScene("Menu");
    }
}
