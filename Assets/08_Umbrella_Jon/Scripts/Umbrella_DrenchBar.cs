using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Umbrella_DrenchBar : MonoBehaviour
{
    [SerializeField] Slider drenchSlider;
    [SerializeField] float drenchIncreaseValue;
    [SerializeField] TextMeshProUGUI drenchValueUI;
    [SerializeField] bool drenchBarOn = false;
    void Start()
    {
        drenchBarOn = false;
    }
       void Update()
    {
        
    }
    public void IncreaseDrenchValue()
    {   if(drenchBarOn == true)
        {
            drenchSlider.value += drenchIncreaseValue;
        }      
    }
    public void UpdateDrenchBarText(float drenchValue)
    {
        drenchValueUI.text = drenchValue.ToString("00.0");
    }
    public void TurnDrenchBarOn()
    {
        drenchBarOn = true;
    }
    public void TurnDrenchBarOff()
    {
        drenchBarOn = false;
    }
}
