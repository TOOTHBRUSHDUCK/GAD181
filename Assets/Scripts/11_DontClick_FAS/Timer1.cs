using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer1 : MonoBehaviour
{
   //to have a timer counting down 
   //when it receaches zero you lose 
    public float timer1 = 10f;
    public void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            EventManager.updateUITextEvent(0, "Time Remaining: " + (int)timer1);

            timer1 -= Time.deltaTime;
            // Debug.Log(timer1);

            if (timer1 <= 0)
            {
                //Debug.Log("win");
                EventManager.microGameCompleteEvent(true);
            }
        }
    }
    
}