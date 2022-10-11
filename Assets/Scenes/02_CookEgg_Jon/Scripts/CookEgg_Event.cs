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
    [SerializeField] Slider progressBar;
    [SerializeField] CookEgg_Timer timer;
    //[SerializeField] bool winGame;

    void Update() 
    {
        GameState();
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
}
