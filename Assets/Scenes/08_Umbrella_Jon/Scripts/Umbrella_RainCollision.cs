using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_RainCollision : MonoBehaviour
{
    //assign this script to particle system
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other) 
    {   
        //if particle system collide with object tagged "Player", it will run the following code
        if(other.tag == "Player")
        {   
            other.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("You have hit the player");
        }
    }
}
