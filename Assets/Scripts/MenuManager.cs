using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Alarm");
    }

    public void ChangePauseState()
    {
        PauseMenu.Instance.ChangePauseState();
    }

    public void OnQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}