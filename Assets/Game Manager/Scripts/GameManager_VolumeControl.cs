using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager_VolumeControl : MonoBehaviour
{
    //assign this script to empty object called volume Controller that placed under Audio parent
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TextMeshProUGUI volumeTextUI = null;
    
    void Start()
    {
        LoadValues();
    }
    //assign to volume slider's on Value Changed, the slider value changed during adjusting slider bar will be translated into slider's text value
    public void SetVolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }  
    //assign to save button
    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }
    //load saved values at start and after clicking save button
    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }        
}
