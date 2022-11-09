using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookEgg_SceneControl : MonoBehaviour
{
    //addign this to empty object scene controller then placed under event management parent
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
