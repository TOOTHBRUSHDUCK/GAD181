using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird_PipeMover : MonoBehaviour
{
    //serialize float for rate to move the pipe at
    [SerializeField] private float pipeMoveRate;

    //serialze vector3 for reset position
    [SerializeField] private Vector3 resetPos;

    //on update:
    private void Update()
    {
        //check whether the pipe's x position is less than -9.5
        if(transform.position.x < -9.5)
        {
            //if true, send it back to 9.5
            transform.position = resetPos;
        }

        //move the pipe left at the pipe movement rate
        transform.position += new Vector3(pipeMoveRate, 0, 0) * Time.deltaTime;
    }

   

    
}
