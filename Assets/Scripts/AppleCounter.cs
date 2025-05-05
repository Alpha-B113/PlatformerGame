using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AppleCounter : MonoBehaviour
{
    public TextMeshProUGUI appleCounter;
    public static int appleCount { get; set; }
    
    private void Awake()
    {
        appleCount = 0;
    }
    void Update()
    {
        appleCounter.text = appleCount.ToString();
    }
}
