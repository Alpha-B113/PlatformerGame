using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI TimerLocation;
    public static float TotalTime { get; private set; }
    public static bool StopTimer { get; set; }

    void Update()
    {
        if (!StopTimer)
            TotalTime += Time.deltaTime;
        var totalSeconds = (int)TotalTime;
        var minutes = (int)(totalSeconds / 60);
        var seconds = (int)(totalSeconds % 60);
        TimerLocation.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
