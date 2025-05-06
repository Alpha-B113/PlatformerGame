using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// review: у меня есть стойкое ощущение, что AppleCounter должен самостоятельно изменять свое состояние через подписку на события
public class AppleCounter : MonoBehaviour
{
    public TextMeshProUGUI appleCounter;
    // review: почему такой кодстайл? Почему свойство? Можно ли сделать не статическим? Я почти уверен, что такой код подталкивает к изменению состояния этого объекта извне
    public static int appleCount { get; set; }

    void Update()
    {
        appleCounter.text = appleCount.ToString();
    }
}
