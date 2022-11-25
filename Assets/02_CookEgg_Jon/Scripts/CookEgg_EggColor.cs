using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookEgg_EggColor : MonoBehaviour
{
    public Color startcolor;
    [SerializeField] public Color decreaseCookingTempColor;
    [SerializeField] public Color increaseCookingtempColor;
    [SerializeField] private CookEgg_ProgressBar progressBar;
    [SerializeField] private Slider temperatureSlider;
    
    void Start()
    {
        NotCooking();
    }
    void Update()
    {
       CookRight();
    }
    //set default color value of the eff
    void NotCooking()
    {
        startcolor = GetComponent<Renderer>().material.color;
        //cookingColor = new Color(1f, 0.67f, 0.11f, 1);
    }
    //color when below minTempValue
    public void UnderCooked()
    {
        GetComponent<Renderer>().material.color = increaseCookingtempColor;
        
        //this is the original code in response to UI
        /*
        if(temperatureSlider.value < progressBar.minTempValue)
        {
            GetComponent<Renderer>().material.color = startcolor;
        }
        */
    }
    //color when between minTempValue nad maxTempValue
    public void CookRight()
    {
        //GetComponent<Renderer>().material.color = startcolor;

        //this is the original code in response to UI
        
        if(temperatureSlider.value > progressBar.minTempValue && temperatureSlider.value < progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = startcolor;
        }
        
    }
    //color when above maxTempValue
    public void OverCooked()
    {
        GetComponent<Renderer>().material.color = decreaseCookingTempColor;

        //this is the original code in response to UI
        /*
        if(temperatureSlider.value > progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = decreaseCookingTempColor;
        }
        */
    }
 
}