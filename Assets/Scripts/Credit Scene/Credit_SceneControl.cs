using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit_SceneControl : MonoBehaviour
{
    void Update() 
    {
        //GamePause();
    }
    //addign this to empty object scene controller then placed under event management parent
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
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
    }
}
