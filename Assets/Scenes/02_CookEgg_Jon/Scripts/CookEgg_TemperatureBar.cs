using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CookEgg_TemperatureBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private float tempertureDrop = 5f;
    [SerializeField] private float tempDropRate = 1.0f;
    void Start()
    {
        TextChange();

        InvokeRepeating("TemperatureChange", 2.0f, tempDropRate);
    }

    void Update()
    {
        
    }

    void TemperatureChange()
    {
        if(slider.value>30 && slider.value<100)
        {
            var x = Random.Range(-tempertureDrop*3, tempertureDrop);
            slider.value -= x;
        }
    }

    void TextChange()
    {
        slider.onValueChanged.AddListener((v) => 
        {
            sliderText.text = v.ToString("00");
        }
        );
    }

}



