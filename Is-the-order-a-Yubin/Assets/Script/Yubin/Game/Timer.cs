using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float timerTime = 0;
    public float dieTime = 10;
    public bool isDie = false;
    string t;

    private void Update()
    {
        timerTime += Time.deltaTime;
        t = timerTime.ToString("N2");
        TimerText.text = t;

        PlayerPrefs.SetString("Time", t);

        if (timerTime > dieTime)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isDie = true;
    }
}
