using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookEgg_Controller : MonoBehaviour
{
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 100f;
    [SerializeField] private float valueChange = 5f;
    [SerializeField] private Slider slider;
    void Start()
    {
        slider.minValue = _minValue;
        slider.maxValue = _maxValue;
    }

    void Update()
    {
        IncreaseTemperatureInput();
        DropTemperatureInput();
    }
    //press w button to increase temperature value
    public void IncreaseTemperatureInput()
    {
        if(Input.GetKeyDown("w")==true)
        {
            IncreaseTemperature();
        }
    }
    //press s button to decrease temperature value
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
        slider.value += valueChange;
    }
    //decrease temperature by valuechange each time the button is pressed
    void DropTemperature()
    {
        slider.value -= valueChange;
    }
}