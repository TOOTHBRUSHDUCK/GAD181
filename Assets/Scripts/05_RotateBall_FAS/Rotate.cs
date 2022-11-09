using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
                                    
    private Vector3 _rotation;
    [SerializeField] private float _speed;

    void Update()
    {
        if (Input.GetKey("w"))
        {
             _rotation = new Vector3(0f,0f,1f);//Vector3.up;
        }
        else if (Input.GetKey("s"))
        {
             _rotation = new Vector3(0f,0f,-1f);//Vector3.down;
        }
        else
        {
             _rotation = Vector3.zero;
        }

        transform.Rotate(_rotation * _speed * Time.deltaTime, Space.World);
        //this.transform.localRotation += _rotation * _speed * Time.deltaTime;
    }
}
