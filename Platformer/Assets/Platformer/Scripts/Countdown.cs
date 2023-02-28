using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Mathf.floor
//float public

public class Countdown : MonoBehaviour
{
    public float seconds;
    private float displayTime;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI TimeMessage;

    void Update()
    {
        if (seconds > 0)
        {
            seconds -= Time.deltaTime;
            displayTime = Mathf.Floor(seconds);
            Timer.text = $"Time\n{displayTime}";
        }

        if (seconds <= 0)
        {
            seconds = 0;
            Timer.text = $"Time\n{seconds}";
            TimeMessage.text = $"Time's up!\nGame Over!";
        }
    }


}
