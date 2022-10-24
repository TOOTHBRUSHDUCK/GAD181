using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DriveInTraffic_Events : MonoBehaviour
{
    public UnityEvent winGameUI;
    public UnityEvent loseGameUI;
    [SerializeField] DriveInTraffic_GoalTrigger goalTrigger;
    [SerializeField] DriveInTraffic_TrafficLight trafficLight;
    void Start()
    {
        
    }
    void Update()
    {
        GameState();
    }
    void GameState()
    {
        if(trafficLight.redLight == false && goalTrigger.reachGoal == true)
        {
            winGameUI.Invoke();
        }
        else if(trafficLight.redLight == true && goalTrigger.reachGoal ==false)
        {
            loseGameUI.Invoke();
        }
    }
}
