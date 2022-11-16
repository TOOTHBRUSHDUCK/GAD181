using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winnerscript : MonoBehaviour
{
    //public float winnerscript;
    public void Update() { }
    public void FixedUpdate()
    {
        //Debug.Log(winnerscript);
        if (Input.anyKeyDown)
        {            
            Debug.Log("you lose");
            EventManager.microGameCompleteEvent(false);
        }
    }
}