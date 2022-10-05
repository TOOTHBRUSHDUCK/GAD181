using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CookEggTemperature : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private float tempertureDrop = 5f;
    [SerializeField] private float tempDropRate = 1.0f;
    void Start()
    {
        slider.onValueChanged.AddListener((v) => 
        {
            sliderText.text = v.ToString("00");
        }
        );

        InvokeRepeating("TemperatureChange", 2.0f, tempDropRate);
    }

    void Update()
    {
        //UpdateProgress();
    }

    //void UpdateProgress()
    //{
    //    if(slider.value>62 && slider.value<70)
    //    {
    //    
    //    }
    //    else if(slider.value>70)
    //    {
    //    
    //    }
    //}

    void TemperatureChange()
    {
        if(slider.value>30 && slider.value<100)
        {
            slider.value -= tempertureDrop;
        }
    }
}



