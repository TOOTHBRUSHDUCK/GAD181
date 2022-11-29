using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CookEgg_TemperatureBar : MonoBehaviour
{
    [SerializeField] private Slider tempSlider;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private float tempertureDrop = 10f;
    [SerializeField] private float tempDropRate = 1.0f;
    void Start()
    {
        TextChange();

        InvokeRepeating("TemperatureChange", 1.0f, tempDropRate);
    }

    void Update()
    {
        
    }

    void TemperatureChange()
    {
        if(tempSlider.value>30 && tempSlider.value<100)
        {
            var x = Random.Range(-tempertureDrop*3, tempertureDrop*3);
            tempSlider.value -= x;
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



