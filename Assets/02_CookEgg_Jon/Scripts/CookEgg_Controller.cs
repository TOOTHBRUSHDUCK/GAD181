using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookEgg_Controller : MonoBehaviour
{
    //setting the min and max value of temperature to limit the temperature range 
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 100f;
    //temeprature change when pressing the W or S button
    [SerializeField] private float valueChange = 5f;
    //temperature slider reference
    [SerializeField] private Slider tempSlider;
    //for reference to the color change function from CookEgg_Eggcolor script attached to Egg
    void Start()
    {
        tempSlider.minValue = _minValue;
        tempSlider.maxValue = _maxValue;
    }

    void Update()
    {
        IncreaseTemperatureInput();
        DropTemperatureInput();
    }
    //press w button to increase temperature value, egg colour changes in response
    public void IncreaseTemperatureInput()
    {
        if(Input.GetKeyDown("w")==true)
        {
            IncreaseTemperature();
        }
    }
    //press s button to decrease temperature value, egg colour changes in response
    public void DropTemperatureInput()
    {
        if(Input.GetKeyDown("s")==true)
        {
            DropTemperature();
        }
    }
    //increase temperature by valuechange each time the button is pressed
    void IncreaseTemperature()
    {
        tempSlider.value += valueChange;
    }
    //decrease temperature by valuechange each time the button is pressed
    void DropTemperature()
    {
        tempSlider.value -= valueChange;
    }
}
