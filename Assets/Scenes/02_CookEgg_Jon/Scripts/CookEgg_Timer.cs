using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookEgg_Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;
    public TextMeshProUGUI timerTxt;

    void Start()
    {
        //timerOn = true;
    }

    void Update()
    {
      SetTimer();
      CountDown();
    }

    void SetTimer()
    {
        if(timerOn==true)
        {
            if(timeLeft>0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is Up!");
                timeLeft = 0;
                timerOn = false;
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void TimerOff()
    {
        timerOn = false;
    }
    //assign to StartGame button to start timer
    public void TimerTurnOn()
    {
        timerOn = true;
    }

    private void CountDown()
    {
        if(timeLeft<3 && timerOn == true)
        {
            timerTxt.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }
}

