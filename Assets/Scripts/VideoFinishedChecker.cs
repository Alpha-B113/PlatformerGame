using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoFinishedChecker : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private void Awake()
    {
        if (videoPlayer.clip == null)
        {
            SceneManager.LoadScene("Room");
            return;
        }
    }

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        audioSource.Play();
        StartCoroutine(LoadSceneAfterSound(4f));
    }

    private IEnumerator LoadSceneAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Room");
    }
}
