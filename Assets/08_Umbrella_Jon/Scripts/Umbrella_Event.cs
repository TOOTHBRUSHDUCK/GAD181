using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Umbrella_Event : MonoBehaviour
{
    public UnityEvent GameStart;
    public UnityEvent WinGameUI;
    public UnityEvent LoseGameUI;
    [SerializeField] Umbrella_Timer timerBar;
    [SerializeField] Slider drenchBar;
    [SerializeField] bool gameOn = false; //turn on running TurnGameOn function by start button
    void Start()
    {
        gameOn = false;
    }

    void Update()
    {
        StartGame();
        GameState();
    }
    void StartGame()
    {
        if(gameOn == true)
        {
            GameStart.Invoke();
        }
    }
    public void TurnGameOn()
    {
        gameOn = true;
    }
    void GameState()
    {
        if(timerBar.timeLeft == 0 && drenchBar.value<100)
        {
            EventManager.microGameCompleteEvent(true);
            //WinGameUI.Invoke();
        }
        else if(timerBar.timeLeft >= 0 && drenchBar.value == 100)
        {
            EventManager.microGameCompleteEvent(false);
            //LoseGameUI.Invoke();
        }
    }

}
