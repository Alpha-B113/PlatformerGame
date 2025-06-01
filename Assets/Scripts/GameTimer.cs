using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI TimerLocation;
    public static float TotalTime { get; private set; }
    public static bool StopTimer { get; set; }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Room")
        {
            StopTimer = false;
            TotalTime = 0f;
        }
    }

    private void Update()
    {
        if (!StopTimer)
            TotalTime += Time.deltaTime;
        var totalSeconds = (int)TotalTime;
        var minutes = (int)(totalSeconds / 60);
        var seconds = (int)(totalSeconds % 60);
        TimerLocation.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
