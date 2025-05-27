using UnityEngine;
using UnityEngine.Serialization;

public class BackgroundMusic : MonoBehaviour
{
    [FormerlySerializedAs("backgroundMusic")] public GameObject backgroundMusic;
    private AudioSource audioSource;
    [FormerlySerializedAs("backgroundMusicPrefab")] public GameObject[] backgroundMusicPrefab;

    void Awake()
    {
        backgroundMusicPrefab = GameObject.FindGameObjectsWithTag("background_music");
        if (backgroundMusicPrefab.Length == 0)
        {
            backgroundMusic = Instantiate(backgroundMusic);
            backgroundMusic.name = "backgroundMusic";
            DontDestroyOnLoad(backgroundMusic.gameObject);
        }
        else
        {
            backgroundMusic = GameObject.Find("backgroundMusic");
        }
    }
    void Start()
    {
        audioSource = backgroundMusic.GetComponent<AudioSource>();
    }
}
