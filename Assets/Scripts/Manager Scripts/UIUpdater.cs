using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    //this script should be attached to an object in each microgame scene and have the variables displayed in the editor set appropriately.

    //bool for top panel being active
    [SerializeField] bool topPanelActive;
    //bool for bottom panel being active
    [SerializeField] bool bottomPanelActive;
    //bool for left panel being active
    [SerializeField] bool leftPanelActive;
    //bool for right panel being active
    [SerializeField] bool rightPanelActive;

    //string for top text
    [TextArea(15, 5)]
    [SerializeField] string topText;

    //string for bottom text
    [TextArea(15, 5)]
    [SerializeField] string bottomText;
    //string for left text
    [TextArea(15, 5)]
    [SerializeField] string leftText;
    //string for right text
    [TextArea(15, 5)]
    [SerializeField] string rightText;

    //on start invoke events to update the different UI elements according to the settings
    private void Start()
    {
        EventManager.toggleUIPanelEvent(0, topPanelActive);
        EventManager.toggleUIPanelEvent(1, bottomPanelActive);
        EventManager.toggleUIPanelEvent(2, leftPanelActive);
        EventManager.toggleUIPanelEvent(3, rightPanelActive);

        EventManager.updateUITextEvent(0, topText);
        EventManager.updateUITextEvent(1, bottomText);
        EventManager.updateUITextEvent(2, leftText);
        EventManager.updateUITextEvent(3, rightText);
    }

    private void OnDestroy()
    {
        EventManager.toggleUIPanelEvent(0, false);
        EventManager.toggleUIPanelEvent(1, false);
        EventManager.toggleUIPanelEvent(2, false);
        EventManager.toggleUIPanelEvent(3, false);
    }
}
