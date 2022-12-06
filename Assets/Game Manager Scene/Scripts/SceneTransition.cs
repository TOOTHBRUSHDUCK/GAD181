using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] AudioSource backgroundAudio;
    [SerializeField] GameObject Snake;
    void Start()
    {
    
    }

    void Update()
    {
        AudioMute();
    }
    void AudioMute()
    {
        if(SceneManager.sceneCount > 1)
        {
            backgroundAudio.mute = true;
            Snake.SetActive(false);
            //Debug.Log("Scene Count is " + SceneManager.sceneCount);
        }
        else
        {
            backgroundAudio.mute = false;
            Snake.SetActive(true);
        }
    }
}
