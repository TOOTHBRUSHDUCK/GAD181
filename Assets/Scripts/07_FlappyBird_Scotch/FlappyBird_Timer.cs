using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlappyBird_Timer : MonoBehaviour
{
    //serialized textmesh pro object referencing the time remaining text 
    private TMP_Text timeRemainText;

    //serialized float for setting the amount of time the player needs to survive to win
    [SerializeField] private float timeRemaining;
    private float timeRemainingDisplay;

    private void OnEnable()
    {
        if(!TryGetComponent<TMP_Text>(out timeRemainText))
        {
            Debug.LogError("You need to attach this script to a TMPro text object!");
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        timeRemainText.text = "Survive for " + timeRemaining + " more seconds!";
    }

    private void Update()
    {
        //on uppdate reduce the time remaining float by time.deltatime
        timeRemaining -= Time.deltaTime;
        timeRemainingDisplay = Mathf.Round(timeRemaining);

        //show the time remaining in the textmeshpro text
        timeRemainText.text = "Survive for " + timeRemainingDisplay + " more seconds!";

        if(timeRemaining < 0)
        {
            EventManager.microGameCompleteEvent(true);
            Debug.Log("You win!");
            //Time.timeScale = 0f;
        }
    }    
}