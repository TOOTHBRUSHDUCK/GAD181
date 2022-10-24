using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DriveInTraffic_TrafficLight : MonoBehaviour
{
    [SerializeField] private DriveInTraffic_Timer timer; 
    [SerializeField] private UnityEvent turnGreenLight;
    [SerializeField] private UnityEvent turnYellowLight;
    [SerializeField] private UnityEvent turnRedLight;
    [SerializeField] public bool redLight;
    void Start()
    {
        redLight = false;
    }

    void Update()
    {
        ChangeTrafficLight();
    }
    private void ChangeTrafficLight()
    {
        if(timer.timeLeft >3)
        {
            turnGreenLight.Invoke();
        }

        else if(timer.timeLeft < 3 && timer.timeLeft >0)
        {
            turnYellowLight.Invoke();
        }
        
        else if(timer.timeLeft == 0)
        {
            turnRedLight.Invoke();
            redLight = true;
        }
    }
}
