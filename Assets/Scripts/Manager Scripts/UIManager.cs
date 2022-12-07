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
    //0 is top
    //1 is bottom
    //2 is left
    //3 is right
    [SerializeField] TMP_Text[] uiTexts;

    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject quitMenu;

    //the 'You Win!' and 'You Lose!' panels
    [SerializeField] GameObject youWinPanel;
    [SerializeField] GameObject youLosePanel;

    //subscribe to relevant events on EventManager
    private void Awake()
    {
        if(youWinPanel != null)
        {
            youWinPanel.SetActive(false);
        }
        if(youLosePanel != null)
        {
            youLosePanel.SetActive(false);
        }

        EventManager.toggleUIPanelEvent += PanelToggle;
        EventManager.updateUITextEvent += UpdateUIText;
        EventManager.togglePauseButtonMenuEvent += PauseButtonToggle;

        EventManager.toggleLosePanelEvent += ToggleYouLose;
        EventManager.toggleWinPanelEvent += ToggleYouWin;

        mainMenuButton.SetActive(false);
        pauseMenu.SetActive(false);
        quitMenu.SetActive(false);
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

    private void PauseButtonToggle(bool toggle)
    {
        mainMenuButton.SetActive(toggle);
    }


    //method for updating the different text
    private void UpdateUIText(int panelID, string panelText)
    {
        //takes in a variable identifying which text is being updated & a string containing the text which the panel should display
        uiTexts[panelID].text = panelText;
    }

    //method for turning the 'you win' panel on or off. take in boolean
    private void ToggleYouWin (bool toggle)
    {
        //if the boolean is true then the panel activates, if false it deactivates
        if(toggle == true)
        {
            youWinPanel.SetActive(true);
        }
        else
        {
            youWinPanel.SetActive(false);
        }
    }

    //method for turning the 'you lose' panel on or off. takes in a boolean
    private void ToggleYouLose(bool toggle)
    {
        //if true then activate the panel, if false then deactivate the panel
        if(toggle == true)
        {
            youLosePanel.SetActive(true);
        }
        else
        {
            youLosePanel.SetActive(false);
        }
    }

    //method for pausing/unpausing the game (will invoke event)

    private void OnDestroy()
    {
        EventManager.toggleUIPanelEvent -= PanelToggle;
        EventManager.updateUITextEvent -= UpdateUIText;
        EventManager.togglePauseButtonMenuEvent -= PauseButtonToggle;
        EventManager.toggleLosePanelEvent -= ToggleYouLose; 
        EventManager.toggleWinPanelEvent -= ToggleYouWin;
    }
}
