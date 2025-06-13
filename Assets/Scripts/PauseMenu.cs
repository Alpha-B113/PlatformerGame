using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public GameObject[] NeedToHideWhileMainMenu;
    public static bool IsMusicOn = true;
    public GameObject PausePlace;
    public Image CheckMark;
    private Canvas canvas;
    private bool someElementsActive = true;

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
        if (SceneManager.GetActiveScene().name == "Menu" && someElementsActive)
        {
            someElementsActive = false;
            ChangeActiveOfSomeElements(someElementsActive);
        }

        if (SceneManager.GetActiveScene().name != "Menu" && !someElementsActive)
        {
            someElementsActive = true;
            ChangeActiveOfSomeElements(someElementsActive);
        }

        if (canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Menu")
        {
            ChangePauseState();
        }
        if (Input.GetKeyDown(KeyCode.M) && canvas.enabled)
        {
            LoadMenu();
        }
    }

    public void ChangePauseState()
    {
        canvas.enabled ^= true;
        Time.timeScale = canvas.enabled ? 0 : 1;
        PausePlace.SetActive(canvas.enabled);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Player.StartPosition = Vector3.zero;
        ChangePauseState();
    }

    private void ChangeActiveOfSomeElements(bool state)
    {
        foreach (var element in NeedToHideWhileMainMenu)
        {
            element.SetActive(state);
        }
    }

    public void ChangeBackgroundMusicState()
    {
        if (IsMusicOn)
            BackGroundMusicOff();
        else
            BackGroundMusicOn();
        IsMusicOn ^= true;
    }

    private void BackGroundMusicOn()
    {
        if (BackgroundMusicManager.Instance != null)
            BackgroundMusicManager.Instance.backgroundMusic.volume = BackgroundMusicManager.Instance.standartVolume;
        CheckMark.enabled = true;
    }

    private void BackGroundMusicOff()
    {
        if (BackgroundMusicManager.Instance != null)
            BackgroundMusicManager.Instance.backgroundMusic.volume = 0f;
        CheckMark.enabled = false;
    }
}
