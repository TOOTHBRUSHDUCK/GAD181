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
    public bool progressOn = false;
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
        ProgressTurnOn();
    }

    
    void Update()
    {
        ProgressChange();
        ProgressColorChange();
    }

    private void ProgressChange()
    {
        if(temperatureSlider.value > minTempValue && temperatureSlider.value <maxTempValue && progressOn == true)
        {
            progressSlider.value += progressIncreaseValue; 
        }
    }

    private void ProgressColorChange()
    {
        if(progressSlider.value < 30 && progressOn)
        {
            sliderText.color = Color.red;
        }
        else if(progressSlider.value >= 30 && progressSlider.value <70)
        {
            sliderText.color = Color.blue;
        }
        else if(progressSlider.value >= 70)
        {
            sliderText.color = Color.green;
        }
    }

    public void ProgressTurnOn()
    {
        progressOn = true;
    }
    public void ProgressTurnOff()
    {
        progressOn = false;
    }    
}
