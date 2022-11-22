using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookEgg_EggColor : MonoBehaviour
{
    private Color startcolor;
    private Color CookingColor;
    [SerializeField] private CookEgg_ProgressBar progressBar;
    [SerializeField] private Slider temperatureSlider;
    
    void Start()
    {
        NotCooking();
    }
    void Update()
    {
        UnderCooked();
        Cooking();
        OverCooked();
    }
    //set default color value of the eff
    void NotCooking()
    {
        startcolor = GetComponent<Renderer>().material.color;
        CookingColor = new Color(1f, 0.67f, 0.11f, 1);
    }
    //color when below minTempValue
    void UnderCooked()
    {
        if(temperatureSlider.value < progressBar.minTempValue)
        {
            GetComponent<Renderer>().material.color = startcolor;
        }
    }
    //color when between minTempValue nad maxTempValue
    void Cooking()
    {
        if(temperatureSlider.value > progressBar.minTempValue && temperatureSlider.value < progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = CookingColor;
        }
    }
    //color when above maxTempValue
    void OverCooked()
    {
        if(temperatureSlider.value > progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
 
}