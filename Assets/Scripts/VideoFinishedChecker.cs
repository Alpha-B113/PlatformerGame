using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoFinishedChecker : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Room");
    }
}
