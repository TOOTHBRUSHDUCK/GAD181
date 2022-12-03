using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CookEgg_TemperatureBar : MonoBehaviour
{
    [SerializeField] private Slider tempSlider;
    //text reference for temperature slider to show temperature value
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private int temperatureFluctuation = 10;
    [SerializeField] private float tempChangeRate = 1.0f;
    [SerializeField] private CookEgg_ProgressBar progress;
    void Start()
    {
        TextChange();

        InvokeRepeating("TemperatureChange", 1.0f, tempChangeRate);
    }

    void Update()
    {
        
    }

    void TemperatureChange()
    {
        if(tempSlider.value > progress.minTempValue && tempSlider.value < progress.maxTempValue)
        {
            var x = Random.Range(0, 2);
            if(x == 0)
            {
                tempSlider.value += temperatureFluctuation;
            }
            else
            {
                tempSlider.value -= temperatureFluctuation;
            }
        }
    }

    void TextChange()
    {
        tempSlider.onValueChanged.AddListener((v) => 
        {
            sliderText.text = v.ToString("00");
        }
        );
    }

}



