using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    public string SceneName;
    public static BackgroundMusicManager Instance;
    public float standartVolume;
    public AudioSource backgroundMusic;

    private void Awake()
    {
        if (Instance == null || Instance.SceneName != SceneName)
        {
            Instance = this;
            backgroundMusic = GetComponent<AudioSource>();
            standartVolume = backgroundMusic.volume;
            if (PauseMenu.Instance != null && !PauseMenu.IsMusicOn)
            {
                backgroundMusic.volume = 0f;
            }
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
