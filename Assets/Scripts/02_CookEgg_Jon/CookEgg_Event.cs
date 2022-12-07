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
    public UnityEvent RemoveButtonSignal;
    public UnityEvent gameStart;
    [SerializeField] AudioSource corretInputAudio;
    [SerializeField] GameObject press_W_Button;
    [SerializeField] GameObject press_S_Button;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] Slider progressBar;
    [SerializeField] Slider temperatureBar;
    [SerializeField] CookEgg_Timer timer;
    [SerializeField] CookEgg_ProgressBar progress;
    //turn on button signal after clikcing start button, turn off button when win/lose UI pops up
    public bool ButtonSignalOn;
    public bool gameOn;

    void Start() 
    {
        TurnOffButtonSignal();
        TurnGameOn();    
    }
    void Update() 
    {

        if (GameManager.Instance.isPaused == false)
        {
            GameState();
        W_Buttonsignal();
        S_Buttonsignal();
        No_Buttonsignal();
        StartGame();
        }
        
       //GamePause();
    }

    void GameState()
    {
        if(progressBar.value<100 && timer.timeLeft==0)
        {
            //loseGameUI.Invoke();
            EventManager.microGameCompleteEvent(false);
            gameOn = false;
        }
        else if(progressBar.value==100 && timer.timeLeft>0)
        {
            //winGameUI.Invoke();
            EventManager.microGameCompleteEvent(true);
            gameOn = false;
        }
    }
    //to pop up W button UI to notify players which button to press 
    void W_Buttonsignal()
    {
        if(ButtonSignalOn == true)
        {
            if(temperatureBar.value <= progress.minTempValue)
            {
                press_W_Button.SetActive(true);
                W_ButtonAudio();
            }
        }                        
    }
    //to pop up S button UI to notify players which button to press 
    void S_Buttonsignal()
    {
        if(ButtonSignalOn == true)
        {
            if(temperatureBar.value >= progress.maxTempValue)
            {
                press_S_Button.SetActive(true);
                S_ButtonAudio();
            }
        }                        
    }
    //Remove button UI 
    void No_Buttonsignal()
    {
        if(ButtonSignalOn == true)
        {
            if(temperatureBar.value > progress.minTempValue && temperatureBar.value < progress.maxTempValue)
            {
                press_W_Button.SetActive(false);
                press_S_Button.SetActive(false);
                W_ButtonAudio();
                S_ButtonAudio();
            }
        }                        
    }
    public void W_ButtonAudio()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            corretInputAudio.Play();
        }
    }
    public void S_ButtonAudio()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            corretInputAudio.Play();
        }
    }

    //Turn on button signal function
    public void TurnOnButtonSignal()
    {
        ButtonSignalOn = true;
    }
    //Turn off button signal function
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
