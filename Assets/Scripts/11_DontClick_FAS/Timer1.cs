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
        timer1 -= Time.deltaTime;
        Debug.Log(timer1);

        if (timer1 <= 0)
        {
            Debug.Log("win");
        }



    }
    
}