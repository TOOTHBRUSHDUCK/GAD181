using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Umbrella_Event : MonoBehaviour
{
    public UnityEvent UmbrellaUp;
    public UnityEvent UmbrellaDown;
    public UnityEvent UmbrellaLeft;
    public UnityEvent UmbrellaRight;
    public UnityEvent GameStart;
    [SerializeField] bool gameOn = false; //turn on by start button
    void Start()
    {
        gameOn = false;
    }

    void Update()
    {
        UmbrellaControl();
        StartGame();
    }
    void UmbrellaControl()
    {
        if(Input.GetKey(KeyCode.W) == true)
        {
            UmbrellaUp.Invoke();
        }
        if(Input.GetKey(KeyCode.S) == true)
        {
            UmbrellaDown.Invoke();
        }
        if(Input.GetKey(KeyCode.A) == true)
        {
            UmbrellaLeft.Invoke();
        }
        if(Input.GetKey(KeyCode.D) == true)
        {
            UmbrellaRight.Invoke();
        }
        
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

}
