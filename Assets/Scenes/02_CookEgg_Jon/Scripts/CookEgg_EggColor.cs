using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookEgg_EggColor : MonoBehaviour
{
    private Color startcolor;
    private Color overCookedColor;
    [SerializeField] private CookEgg_ProgressBar progressBar;
    [SerializeField] private Slider tempSlider;
    
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
    
    void NotCooking()
    {
        startcolor = GetComponent<Renderer>().material.color;
        overCookedColor = new Color(1f, 0.67f, 0.11f, 1);
    }

    void UnderCooked()
    {
        if(tempSlider.value < progressBar.minTempValue)
        {
            GetComponent<Renderer>().material.color = startcolor;
        }
    }
    void Cooking()
    {
        if(tempSlider.value > progressBar.minTempValue && tempSlider.value < progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    void OverCooked()
    {
        if(tempSlider.value > progressBar.maxTempValue)
        {
            GetComponent<Renderer>().material.color = overCookedColor;
        }
    }
 
}