using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveInTraffic_Controller : MonoBehaviour
{
    //value for speed
    [SerializeField] private int moveSpeed;
    private int defaultMoveSpeed;
    [SerializeField] private int speedBoost = 10;
    [SerializeField] private int turnSpeed;
    //value for jump function
    /*[SerializeField] private int jumpHeight;
    
    [SerializeField] private bool isGrounded;
    
    [SerializeField] private Rigidbody rig;
    */
    [SerializeField] AudioSource speedBoostAudio;
    private bool freezeMovement = false;
    void Start()
    {
        defaultMoveSpeed = moveSpeed;
    }    
    void Update()
    {
        if(GameManager.Instance.isPaused==false)
        {
            freezeMovement = false;
            MovementControl();
        }
        else
        {
            freezeMovement = true;
        }
    }
    void MovementControl()
    {       
        //move forwadrs
        if (Input.GetKey(KeyCode.W) == true && freezeMovement == false)
        { 
            this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
        }
        //move backwards
        if (Input.GetKey(KeyCode.S) == true && freezeMovement == false)
        { 
            this.transform.position -= this.transform.forward * moveSpeed * Time.deltaTime;            
        }
        //float angle = turnspeed * Time.deltaTime ; positive value of turnspeed will turn the object clockwise(turn right)
        if (Input.GetKey(KeyCode.D) == true && freezeMovement == false)
        { 
            this.transform.RotateAround(this.transform.position, Vector3.up, turnSpeed * Time.deltaTime);            
        }
        //float angle = -turnspeed * Time.deltaTime ; negative value of turnspeed will turn the object anti-clockwise(turn left)
        if (Input.GetKey(KeyCode.A) == true && freezeMovement == false)
        { 
            this.transform.RotateAround(this.transform.position, Vector3.up, -turnSpeed * Time.deltaTime); 
            
        }
        //detect if game object is on the ground
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            moveSpeed += speedBoost;
            speedBoostAudio.Play();
            speedBoostAudio.mute = false;
        }
        else if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            moveSpeed = defaultMoveSpeed;
            speedBoostAudio.mute = true;
        }
    }
    
    /*private void OnCollisionEnter(Collision other)
    {
        //contact point of two objects if contacts distance set to zero, Vector3.up because jumping will bounce charcter upwards
        if(other.contacts[0].normal == Vector3.up)
            {
                isGrounded = true;
            }
    }*/
}

