using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
   //to have a timer counting down 
   //when it receaches zero you lose 
    private float timer = 10f;
    private void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer <= 0)
        {
            Debug.Log("you lose");
        }



    }
    
}
