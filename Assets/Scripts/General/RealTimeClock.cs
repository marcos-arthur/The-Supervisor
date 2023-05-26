using UnityEngine;
using TMPro;
using System;

public class RealTimeClock : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    void Update()
    {
        // Get the current system time
        DateTime currentTime = DateTime.Now;

        // Format the time and date as a string
        string timeString = currentTime.ToString("HH:mm:ss");
        string dateString = currentTime.ToString("dd/MM/yyyy");

        // Update the clock text
        clockText.text = " " + timeString + "\n" + dateString;
    }
}