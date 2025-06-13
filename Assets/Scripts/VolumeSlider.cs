using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Scrollbar scrollbar;

    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    private void Start()
    {
        var savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        scrollbar.value = savedVolume;
        AudioListener.volume = savedVolume;
        scrollbar.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}
