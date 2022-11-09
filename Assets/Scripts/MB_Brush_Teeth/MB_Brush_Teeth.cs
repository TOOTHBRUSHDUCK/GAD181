using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Brush_Teeth : MB_HoldButt
{
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public override void DoOnHold()
    {
        //Debug.Log("called");
        if(this.transform.position.x >= 2)
        {
            rb.velocity = new Vector3(-0.8f,0,0) * (heldTime+2);
        }
        else if (this.transform.position.x <= -2)
        {
            rb.velocity = new Vector3(0.8f,0,0) * (heldTime+2);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0.8f,0,0) * (heldTime+2);
        }
        else if(rb.velocity.x < 0)
        {
            rb.velocity = new Vector3(-0.8f,0,0) * (heldTime+2);
        }
        else
        {
            rb.velocity = new Vector3(0.8f,0,0) * (heldTime+2);
        }
    }
}
