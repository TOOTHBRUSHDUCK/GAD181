using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winnerscript : MonoBehaviour
{
    public float winnerscript;
    public void Update()
    function FixedUpdate()
    {
        Debug.Log(winnerscript);
        if (Input.anyKeyDown) ;
        {
            Input.anyKeyDown = true;
            Debug.Log("you lose");
        }
    }
}