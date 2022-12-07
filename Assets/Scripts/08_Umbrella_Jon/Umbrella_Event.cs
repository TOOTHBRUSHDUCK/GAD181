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
    [SerializeField] GameObject PauseMenu;
    [SerializeField] bool gameOn = false; //turn on running TurnGameOn function by start button
    void Start()
    {
        TurnGameOn();
    }

    void Update()
    {
        StartGame();
        GameState();
        GamePause();
    }
    void StartGame()
    {
        if(gameOn == true && Time.timeScale != 0)
        {
            GameStart.Invoke();
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
    void GameState()
    {
        if(timerBar.timeLeft == 0 && drenchBar.value > 0 && Time.timeScale != 0)
        {
            EventManager.microGameCompleteEvent(true);
            //WinGameUI.Invoke();
        }
        else if(timerBar.timeLeft >= 0 && drenchBar.value < 1 && Time.timeScale != 0)
        {
            EventManager.microGameCompleteEvent(false);
            //LoseGameUI.Invoke();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        //PauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        //PauseMenu.SetActive(false);
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
