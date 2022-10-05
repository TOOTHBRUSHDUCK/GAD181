using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CookEgg_ProgressBar : MonoBehaviour
{
    [SerializeField] private float progressIncreaseValue;
    [SerializeField] private float progressIncreaseRate;
    [SerializeField] private Slider temperatureSlider; 
    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI sliderText;
    public float minTempValue;
    public float maxTempValue;

    void Start()
    {
        progressSlider.onValueChanged.AddListener((v) =>
        {
            sliderText.text = v.ToString("000");
        }
        );

        InvokeRepeating("ProgressChange", 1.0f, progressIncreaseRate);
    }

    
    void Update()
    {
        ProgressChange();
    }

    private void ProgressChange()
    {
        if(temperatureSlider.value > minTempValue && temperatureSlider.value <maxTempValue)
        {
            progressSlider.value += progressIncreaseValue; 
        }
    }
}
