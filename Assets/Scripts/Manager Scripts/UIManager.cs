using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Script will be responsible for toggling different elements of the UI contained on the canvas in the GameManager scene.

    //reference to the 'top panel'
    [SerializeField] GameObject topPanel;
    //reference to the 'bottom panel'
    [SerializeField] GameObject bottomPanel;
    //reference to the 'left panel'
    [SerializeField] GameObject leftPanel;
    //reference to the 'right panel'
    [SerializeField] GameObject rightPanel;

    //reference to the 'top panel text'
    [SerializeField] TMP_Text topText;
    //reference to the 'bottom panel text'
    [SerializeField] TMP_Text bottomText;
    //reference to the 'left panel text'
    [SerializeField] TMP_Text leftText;
    //refernce to the 'right panel text'
    [SerializeField] TMP_Text rightText;

    //subscribe to relevant events on EventManager

    //method for toggling panels on/off
    //takes in variable to determine which panel is being toggled on/off
    //toggles a panel on or off depending on the input variable

    //method for updating the different text
    //takes in a variable identifying which text is being updated & a string containing the text which the panel should display

    //method for pausing/unpausing the game (will invoke event)
}
