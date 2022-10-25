using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveInTraffic_Controller : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] private int turnSpeed;
    [SerializeField] private int jumpHeight;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Rigidbody rig;

    void Start()
    {

    }    
    void Update()
    {
        MovementControl();
    }
    void MovementControl()
    {       
        //move forwadrs
        if (Input.GetKey(KeyCode.W) == true)
        { 
            this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
        }
        //move backwards
        if (Input.GetKey(KeyCode.S) == true)
        { 
            this.transform.position -= this.transform.forward * moveSpeed * Time.deltaTime;            
        }
        //float angle = turnspeed * Time.deltaTime ; positive value of turnspeed will turn the object clockwise(turn right)
        if (Input.GetKey(KeyCode.D) == true)
        { 
            this.transform.RotateAround(this.transform.position, Vector3.up, turnSpeed * Time.deltaTime);            
        }
        //float angle = -turnspeed * Time.deltaTime ; negative value of turnspeed will turn the object anti-clockwise(turn left)
        if (Input.GetKey(KeyCode.A) == true)
        { 
            this.transform.RotateAround(this.transform.position, Vector3.up, -turnSpeed * Time.deltaTime); 
            
        }
        //detect if game object is on the ground
        if (Input.GetKey(KeyCode.Space) == true && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * this.jumpHeight, ForceMode.Impulse);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        //contact point of two objects if contacts distance set to zero, Vector3.up because jumping will bounce charcter upwards
        if(other.contacts[0].normal == Vector3.up)
            {
                isGrounded = true;
            }
    }
}

