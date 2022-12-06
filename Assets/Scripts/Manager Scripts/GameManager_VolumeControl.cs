using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager_VolumeControl : MonoBehaviour
{
    //assign this script to empty object called volume Controller that placed under Audio parent
    [SerializeField] private Slider gameManager_VolumeSlider = null;
    [SerializeField] private Slider InGame_VolumeSlider = null;
    [SerializeField] private TextMeshProUGUI gameManager_volumeTextUI = null;
    [SerializeField] private TextMeshProUGUI InGame_volumeTextUI = null;
    
    void Start()
    {
        Load_GM_Values();
        Load_IG_Values();
    }
    //assign to volume slider's on Value Changed, the slider value changed during adjusting slider bar will be translated into slider's text value
    public void GM_SetVolumeSlider(float volume)
    {
        gameManager_volumeTextUI.text = volume.ToString("0.0");
    }  
    public void IG_SetVolumeSlider(float volume)
    {
        InGame_volumeTextUI.text = volume.ToString("0.0");
    }  
    //assign to save button
    public void GM_SaveVolumeButton()
    {
        float GMvolumeValue = gameManager_VolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", GMvolumeValue);
        Load_GM_Values();
    }
    public void IG_SaveVolumeButton()
    {
        float IGvolumeValue = InGame_VolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", IGvolumeValue);
        Load_IG_Values();
    }
    //load saved values at start and after clicking save button
    public void Load_GM_Values()
    {
        float GMvolumeValue = PlayerPrefs.GetFloat("VolumeValue");
        gameManager_VolumeSlider.value = GMvolumeValue;
        AudioListener.volume = GMvolumeValue;
    }
    public void Load_IG_Values()
    {
        float IGvolumeValue = PlayerPrefs.GetFloat("VolumeValue");
        InGame_VolumeSlider.value = IGvolumeValue;
        AudioListener.volume = IGvolumeValue;
    }
    public void CloseVolumeButton()
    {
        Load_GM_Values();
        Load_IG_Values();
    } 
}
