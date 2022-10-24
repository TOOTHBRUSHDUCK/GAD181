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
    [SerializeField] Slider progressBar;
    [SerializeField] Slider temperatureBar;
    [SerializeField] CookEgg_Timer timer;
    //turn on button signal after clikcing start button, turn off button when win/lose UI pops up
    public bool ButtonSignalOn = false;
    //[SerializeField] bool winGame;

    void Update() 
    {
        GameState();
        Buttonsignal();
    }

    void GameState()
    {
        if(progressBar.value<100 && timer.timeLeft==0)
        {
            //winGame = false;
            loseGameUI.Invoke();
        }
        else if(progressBar.value==100 && timer.timeLeft>0)
        {
            //winGame = true;
            winGameUI.Invoke();
        }
    }
    //to pop up W or S button UI to notify players which button to press 
    void Buttonsignal()
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

    public void TurnOnButtonSignal()
    {
        ButtonSignalOn = true;
    }
    public void TurnOffButtonSignal()
    {
        ButtonSignalOn = false;
    }
}
