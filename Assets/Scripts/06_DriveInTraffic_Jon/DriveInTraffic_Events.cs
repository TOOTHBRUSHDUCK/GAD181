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
    [SerializeField] DriveInTraffic_ImpactTrigger playerCarImpactTrigger;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] private bool gameOn; //set true by start button
    void Start()
    {
        TurnGameOn();
    }
    void Update()
    {
        if (GameManager.Instance.isPaused == false)
        {
            StartGame();
            GameState();
        }
        //GamePause();
    }
    void GameState()
    {
        if(Time.timeScale != 0)
        {
            if(trafficLight.redLight == false && goalTrigger.reachGoal == true)
            {
                //winGameUI.Invoke();
                EventManager.microGameCompleteEvent(true);
                gameOn = false;
            }
            else if(trafficLight.redLight == true && goalTrigger.reachGoal ==false || playerCarImpactTrigger.initialCarHP <= 0)
            {
                //loseGameUI.Invoke();
                EventManager.microGameCompleteEvent(false);
                gameOn = false;
            }
        }        
    }
    void StartGame()
    {
        if(gameOn == true && Time.timeScale !=0)
        {
            gameStart.Invoke();
        }
    }
    public void TurnGameOn()
    {
        gameOn = true;
    }
    public void TurnGameOff()
    {
        gameOn = false;
    }
        void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    void GamePause()
    {
        if(GameManager.Instance.isPaused == true)
        {
            if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
        }
        else
        {
            Time.timeScale = 1;
        }
        
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale != 0)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }*/
    }
}
