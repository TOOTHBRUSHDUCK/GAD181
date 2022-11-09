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
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer <= 0)
        {
            Debug.Log("you lose");
        }



    }
    
}
