using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Umbrella_Controller : MonoBehaviour
{
    public UnityEvent UmbrellaUp;
    public UnityEvent UmbrellaDown;
    public UnityEvent UmbrellaLeft;
    public UnityEvent UmbrellaRight;
    void Start()
    {
        
    }

    void Update()
    {
        UmbrellaControl();
    }
    void UmbrellaControl()
    {
        if(Input.GetKey(KeyCode.W) == true)
        {
            UmbrellaUp.Invoke();
        }
        if(Input.GetKey(KeyCode.S) == true)
        {
            UmbrellaDown.Invoke();
        }
        if(Input.GetKey(KeyCode.A) == true)
        {
            UmbrellaLeft.Invoke();
        }
        if(Input.GetKey(KeyCode.D) == true)
        {
            UmbrellaRight.Invoke();
        }
        
    }
}
