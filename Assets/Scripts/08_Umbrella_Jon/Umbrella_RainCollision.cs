using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Umbrella_RainCollision : MonoBehaviour
{
    //assign this script to particle system
    [SerializeField] Umbrella_DrenchBar drenchBar;
    [SerializeField] Color playerStartColor;
    [SerializeField] GameObject player;
    void Start()
    {
        SavePlayerInitialColor();
    }
    void Update()
    {
        LoadPlayerInitialColor();
    }
    private void OnParticleCollision(GameObject other) 
    {   
        //if particle system collide with object tagged "Player", it will run the following code
        if(other.tag == "Player")
        {   
            other.GetComponent<Renderer>().material.color = Color.red;
            drenchBar.IncreaseDrenchValue();
            //Debug.Log("You have hit the player");
        }
        else
        {
            player.GetComponent<Renderer>().material.color = playerStartColor;
        }

    }
    private void SavePlayerInitialColor()
    {
        playerStartColor = player.GetComponent<Renderer>().material.color;
    }
    private void LoadPlayerInitialColor()
    {
        player.GetComponent<Renderer>().material.color = playerStartColor;
    }
}
