using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird_PlayerController : MonoBehaviour
{
    //serialized variable float to use as multiplier use when calculating how much to increase velocity by each 'flap'
    [SerializeField] private float flapMultiplier;

    //serialized variable float for maximum downward velocity
    [SerializeField] private float downVelMax;

    //serialized variable float for input cooldown max
    [SerializeField] private float inputCooldownMax;

    //float variable for current input cooldown
    private float inputCooldown;

    //rigidbody variable for the player character (bird/helicopter)
    private Rigidbody birdBody;

    //on enable 
    private void OnEnable()
    {
        //check if there is a rigidbody component attached to the player character and automatically assign the variable
        if(!TryGetComponent<Rigidbody>(out birdBody))
        {   
            //throw logerror and disable gameobject if no rigidbody is found
            Debug.LogError("You need to attach a rigidbody to the object!");
            gameObject.SetActive(false);
        }
    }

    
    
    private void Start()
    {
        //on start set the Z velocity of the player character to 0
        birdBody.velocity = Vector3.zero;

        //set the cooldown variable to -1
        inputCooldown = -1f;
    }

    //on update:
    private void Update()
    {
        //increase Z velocity (apply force) of player character, interpolating between current velocity and max velocity over time
        
        if(birdBody.velocity.z > downVelMax)
        {
            birdBody.velocity += -Vector3.forward * 0.1f;
        }
            //Vector3.Slerp(birdBody.velocity, new Vector3(0, 0, downVelMax), Time.deltaTime);

        //if the player presses spacebar and cooldown is less than 0:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(inputCooldown < 0)
            {
                inputCooldown = inputCooldownMax;
                birdBody.velocity += Vector3.forward * flapMultiplier;
                //birdBody.AddForce(Vector3.forward * flapMultiplier, ForceMode.Impulse);
            }
        }

        //if the cooldown is over 0 reduce it by time.deltatime
        if(inputCooldown > 0)
        {
            inputCooldown -= Time.deltaTime;
        }

    }








}
