using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
   //to have a timer counting down 
   //when it receaches zero you lose 
    public float timer = 10f;
    public void Update()
    {
        if (GameManager.Instance.isPaused == false)
        {
            timer -= Time.deltaTime;
            //Debug.Log(timer);

            EventManager.updateUITextEvent(0, "Time remaining: " + (int)timer);

            if (timer <= 0)
            {
                Debug.Log("you lose");
                EventManager.microGameCompleteEvent(false);
            }
        }

    }
    
}
