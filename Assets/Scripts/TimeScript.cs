using UnityEngine;
using TMPro;
using System;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float elapsedTime = 0f;
    private DateTime startTime;

    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("TimeText (TextMeshProUGUI) is not assigned!");
            return;
        }

        // 開始時間を8:29:00に設定
        startTime = DateTime.Today.AddHours(8).AddMinutes(29);
        UpdateTimeDisplay();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        DateTime currentTime = startTime.AddSeconds(elapsedTime);
        timeText.text = currentTime.ToString("HH:mm:ss");
    }
}