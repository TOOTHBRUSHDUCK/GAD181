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
    [SerializeField] private TextMeshProUGUI progressSliderText;
    public bool progressOn = false;
    //minimum temperature value for cooking progress to increase
    public float minTempValue;
    //maximum temperature value for cooking progress to increase
    public float maxTempValue;

    void Start()
    {
        progressSlider.onValueChanged.AddListener((v) =>
        {
            progressSliderText.text = v.ToString("000");
        }
        );

        InvokeRepeating("ProgressChange", 1.0f, progressIncreaseRate);
        ProgressTurnOn();
    }

    
    void Update()
    {
        if(GameManager.Instance.isPaused==false)
        {
        ProgressChange();
        ProgressColorChange();
        }
    }
    //progress value will only increase if temperature slider value is in between minTempValue and maxTempValue
    private void ProgressChange()
    {
        if(temperatureSlider.value > minTempValue && temperatureSlider.value < maxTempValue && progressOn == true)
        {
            progressSlider.value += progressIncreaseValue*Time.deltaTime; 
        }
    }
    //changes progress text colour in response to progress value
    private void ProgressColorChange()
    {
        if(progressSlider.value < 30 && progressOn)
        {
            progressSliderText.color = Color.red;
        }
        else if(progressSlider.value >= 30 && progressSlider.value <70)
        {
            progressSliderText.color = Color.blue;
        }
        else if(progressSlider.value >= 70)
        {
            progressSliderText.color = Color.green;
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
