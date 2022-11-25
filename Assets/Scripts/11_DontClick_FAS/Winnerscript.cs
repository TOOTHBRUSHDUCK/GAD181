using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winnerscript : MonoBehaviour
{
    //public float winnerscript;
  
    public void Update()
    {
        //Debug.Log(winnerscript);
        if (Input.anyKeyDown)
        {            
            Debug.Log("you lose");
            EventManager.microGameCompleteEvent(false);
        }
    }
}