using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Script will be responsible for toggling different elements of the UI contained on the canvas in the GameManager scene.

    //array of panels
    //0 is top
    //1 is bottom
    //2 is left
    //3 is right
    [SerializeField] GameObject[] panels;

    //array of text to display in UI
    //1 is top
    //2 is bottom
    //3 is left
    //4 is right
    [SerializeField] TMP_Text[] uiTexts;

    //subscribe to relevant events on EventManager
    private void Awake()
    {
        EventManager.toggleUIPanelEvent += PanelToggle;
        EventManager.updateUITextEvent += UpdateUIText;
    }

    private void Start()
    {
        
    }

    //method for toggling panels on/off
    private void PanelToggle(int panelID, bool active)
    {
        //takes in variable to determine which panel is being toggled on/off
        //toggles a panel on or off depending on the input variables
        panels[panelID].SetActive(active);
    }


    //method for updating the different text
    private void UpdateUIText(int panelID, string panelText)
    {
        //takes in a variable identifying which text is being updated & a string containing the text which the panel should display
        uiTexts[panelID].text = panelText;
    }

    //method for pausing/unpausing the game (will invoke event)

    private void OnDestroy()
    {
        EventManager.toggleUIPanelEvent -= PanelToggle;
        EventManager.updateUITextEvent -= UpdateUIText;
    }
}
