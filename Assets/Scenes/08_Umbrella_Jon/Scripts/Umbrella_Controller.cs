using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_Controller : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        UmbrellaMovement();
    }

    private void UmbrellaMovement()
    {
        if(Input.GetKey(KeyCode.W) == true)
        {
            this.transform.RotateAround(this.transform.position, Vector3.left, -rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) == true)
        {
            this.transform.RotateAround(this.transform.position, Vector3.left, rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) == true)
        {
            this.transform.RotateAround(this.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D) == true)
        {
            this.transform.RotateAround(this.transform.position, Vector3.forward, -rotateSpeed * Time.deltaTime);
        }
    }
}
