using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookEgg_Event : MonoBehaviour
{
    public UnityEvent winGameUI;
    public UnityEvent loseGameUI;
    public UnityEvent Load_W_Button;
    public UnityEvent Load_S_Button;
    public UnityEvent RemoveButtonSignal;
    public UnityEvent gameStart;
    [SerializeField] Slider progressBar;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] Slider temperatureBar;
    [SerializeField] CookEgg_Timer timer;
    //turn on button signal after clikcing start button, turn off button when win/lose UI pops up
    public bool ButtonSignalOn;
    public bool gameOn;
    //[SerializeField] bool winGame;

    void Start() 
    {
        TurnOffButtonSignal();
        TurnGameOn();    
    }
    void Update() 
    {
        GameState();
        Buttonsignal();
        StartGame();
        GamePause();
    }

    void GameState()
    {
        if(progressBar.value<100 && timer.timeLeft==0)
        {
            //winGame = false;
            //loseGameUI.Invoke();
            EventManager.microGameCompleteEvent(true);
            gameOn = false;
        }
        else if(progressBar.value==100 && timer.timeLeft>0)
        {
            //winGame = true;
            //winGameUI.Invoke();
            EventManager.microGameCompleteEvent(false);
            gameOn = false;
        }
    }
    //to pop up W or S button UI to notify players which button to press 
    void Buttonsignal()
    {
        if(Time.timeScale != 0)
        {
            if(temperatureBar.value<40 && ButtonSignalOn == true)
            {
                Load_W_Button.Invoke();
            }
            else if(temperatureBar.value>60 && ButtonSignalOn == true)
            {
                Load_S_Button.Invoke();
            }
            else if(temperatureBar.value>40 && temperatureBar.value<60 && ButtonSignalOn == true)
            {
                RemoveButtonSignal.Invoke();
            }
        }                        
    }
    //show button signal
    public void TurnOnButtonSignal()
    {
        ButtonSignalOn = true;
    }
    //remove button signal
    public void TurnOffButtonSignal()
    {
        ButtonSignalOn = false;
    }
    private void StartGame()
    {
        if(gameOn == true && Time.timeScale != 0)
        {
            gameStart.Invoke();
        }
    }
    public void TurnGameOn()
    {
        gameOn = true;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale != 0)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
}
