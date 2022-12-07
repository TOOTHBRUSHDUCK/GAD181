using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriveInTraffic_SceneLoader : MonoBehaviour
{
    //assign which animator to play during scene transition 
    public Animator transitionAnimator;
    //set how long to wait before loading the next scene, can adjust based on how long of the animation
    public float transitionTime = 1f;
    void Update()
    {
        
    }

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
