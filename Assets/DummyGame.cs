using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GoBackWin();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            GoBackLose();
        }
    }

    private void GoBackWin()
    {
        Debug.Log("For testing purposes you have won the game");
        EventManager.microGameCompleteEvent(true);
    }

    private void GoBackLose()
    {
        Debug.Log("For testing purposes you have lost the game");
        EventManager.microGameCompleteEvent(false);
    }
}
