using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveInTraffic_Dropper : MonoBehaviour
{   
    [SerializeField] private float timeToWait = 3f;
    private MeshRenderer render;
    private Rigidbody rigidBody;
    [SerializeField] private bool dropperOn;
    void Start()
    {
        SetDropper();
    }
    void Update()
    {
        WaitThenDrop();
    }
    void SetDropper()
    {
        render = GetComponent<MeshRenderer>();
        render.enabled = false;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        dropperOn = false;
    }
    void WaitThenDrop()
    {
        if(Time.time > timeToWait && dropperOn == true)
        {
            render.enabled = true;
            rigidBody.useGravity = true;
        }
    }
    public void TurnDropperOn()
    {
        dropperOn = true;
    }
}
