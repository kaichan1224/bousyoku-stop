using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public void SetTime(float time)
    {
        timerText.text = $"Time {time.ToString("F0")}s";
    }
}
