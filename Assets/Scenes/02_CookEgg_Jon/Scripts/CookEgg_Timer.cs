using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookEgg_Timer : MonoBehaviour
{
    //assign to timer panel under main canvas
    public float timeLeft;
    public bool timerOn = false;
    public TextMeshProUGUI timerTxt;

    void Start()
    {

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
    //turn off the timer, default at start then turn off again when game ends
    public void TimerOff()
    {
        timerOn = false;
    }
    //turn on the timer, set the timerOn to true when game starts
    public void TimerTurnOn()
    {
        timerOn = true;
    }
    //changes text colour if timeleft<3  
    private void CountDown()
    {
        if(timeLeft<3 && timerOn == true)
        {
            timerTxt.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }
}

