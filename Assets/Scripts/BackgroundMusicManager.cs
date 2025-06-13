using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    public string SceneName;
    private static BackgroundMusicManager Instance;
    private AudioSource backgroundMusic;

    private void Awake()
    {
        if (Instance == null || Instance.SceneName != SceneName)
        {
            Instance = this;
            backgroundMusic = GetComponent<AudioSource>();
            return;
        }
        Destroy(gameObject);
        return;
    }

    private void Start()
    {
        backgroundMusic.Play();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneName != SceneManager.GetActiveScene().name)
        {
            Destroy(gameObject);
            return;
        }
    }
}
