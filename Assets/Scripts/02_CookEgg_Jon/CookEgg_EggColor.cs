using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookEgg_EggColor : MonoBehaviour
{
    //assign the default colour of the egg when CookRight
    public Color startcolor;
    //assign colour of the egg when overcooked
    [SerializeField] public Color decreaseCookingTempColor;
    //assign colour of the egg when overcooked
    [SerializeField] public Color increaseCookingtempColor;
    [SerializeField] private CookEgg_ProgressBar progressBar;
    [SerializeField] private Slider temperatureSlider;
    
    void Start()
    {
        NotCooking();
    }
    void Update()
    {
        if(GameManager.Instance.isPaused == false)
        {
        UnderCooked();
        CookRight();
        OverCooked();
        }
    }
    //declare the startcolor as the default color value of the egg
    void NotCooking()
    {
        startcolor = GetComponent<Renderer>().material.color;
    }
    //color when below minTempValue
    public void UnderCooked()
    {
        if(temperatureSlider.value <= progressBar.minTempValue)
        {
            GetComponent<Renderer>().material.color = increaseCookingtempColor;
        }
    
    }
    //color when between minTempValue and maxTempValue
    public void CookRight()
    {
        if(temperatureSlider.value > progressBar.minTempValue && temperatureSlider.value < progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = startcolor;
        }
        
    }
    //color when above maxTempValue
    public void OverCooked()
    {
        if(temperatureSlider.value >= progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = decreaseCookingTempColor;
        }
    }
 
}