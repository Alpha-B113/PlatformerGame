using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Canvas canvas;
    public static PauseMenu Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        canvas = GetComponent<Canvas>();
        Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameState();
        }
        if (Input.GetKeyDown(KeyCode.M) && canvas.enabled)
        {
            LoadMenu();
        }
    }

    public void ChangeGameState()
    {
        canvas.enabled ^= true;
        Time.timeScale = canvas.enabled ? 0 : 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Destroy(Instance.gameObject);
        Instance = null;
        Time.timeScale = 1;
    }
}
