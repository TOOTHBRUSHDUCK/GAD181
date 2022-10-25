using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DriveInTraffic_Events : MonoBehaviour
{
    public UnityEvent winGameUI;
    public UnityEvent loseGameUI;
    public UnityEvent gameStart;
    [SerializeField] DriveInTraffic_GoalTrigger goalTrigger;
    [SerializeField] DriveInTraffic_TrafficLight trafficLight;
    [SerializeField] private bool gameOn; //set true by start button
    void Start()
    {
        gameOn = false;
    }
    void Update()
    {
        GameState();
        StartGame();
    }
    void GameState()
    {
        if(trafficLight.redLight == false && goalTrigger.reachGoal == true)
        {
            winGameUI.Invoke();
            gameOn = false;
        }
        else if(trafficLight.redLight == true && goalTrigger.reachGoal ==false)
        {
            loseGameUI.Invoke();
            gameOn = false;
        }
    }
    void StartGame()
    {
        if(gameOn == true)
        {
            gameStart.Invoke();
        }
    }
    public void TurnGameOn()
    {
        gameOn = true;
    }
}
