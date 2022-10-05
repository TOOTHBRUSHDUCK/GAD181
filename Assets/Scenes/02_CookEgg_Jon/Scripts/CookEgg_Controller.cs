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
        MoveTemperature();
    }

    void MoveTemperature()
    {
        if(Input.GetKeyDown("w"))
        {
            slider.value += valueChange;
        }
        else if(Input.GetKeyDown("s"))
        {
            slider.value -= valueChange;
        }
    }
}
