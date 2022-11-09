using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird_KillBox : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if any object entering the trigger collider is tagged as 'player'
        if(other.tag == "Player")
        {
            //if yes then invoke the game over event on eventmanager
            Debug.Log("You lose!");
            EventManager.microGameCompleteEvent(false);
            //Time.timeScale = 0;
        }

    }
}
