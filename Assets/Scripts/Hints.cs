using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{

    public string HintText;
    public HintTrigger Trigger;

    private Animator animator;
    private TextMeshProUGUI hintLocation;
    private Image image;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hintLocation = GetComponentInChildren<TextMeshProUGUI>();
        hintLocation.gameObject.SetActive(false);
        image = GetComponent<Image>();
        HideHintLocation();
    }

    private void HideHintLocation()
    {
        var color = image.color;
        color.a = 0f;
        image.color = color;
    }

    private void ShowHintLocation()
    {
        var color = image.color;
        color.a = 1f;
        image.color = color;
    }

    private void Update()
    {
        if (Trigger.IsTriggeredToShow)
        {
            Trigger.IsTriggeredToShow = false;
            ShowHint();
        }

        if (Trigger.IsTriggeredToHide)
        {
            Trigger.IsTriggeredToHide = false;
            HideHint();
        }
    }

    private void ShowHint()
    {
        ShowHintLocation();
        if (HintText == "Ваш результат: ")
        {
            GameTimer.StopTimer = true;
            var totalSeconds = GameTimer.TotalTime;
            var minutes = (int)(totalSeconds / 60);
            var seconds = (int)(totalSeconds % 60);
            HintText += string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        hintLocation.text = HintText;
        animator.SetTrigger("isOpening");
        Invoke("ShowText", 0.3f);
    }

    private void HideHint()
    {
        animator.SetTrigger("isClosing");
        Invoke("HideText", 0.2f);
    }

    private void ShowText()
    {
        hintLocation.gameObject.SetActive(true);
    }

    private void HideText()
    {
        hintLocation.gameObject.SetActive(false);
    }
}
