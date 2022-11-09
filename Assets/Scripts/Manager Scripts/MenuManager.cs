using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.closeMenuEvent += CloseMenus;
        EventManager.returnMainMenuEvent += LoadMainMenu;
    }

    private void CloseMenus()
    {
        mainMenu.SetActive(false);
    }

    private void LoadMainMenu()
    {
        mainMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        EventManager.closeMenuEvent -= CloseMenus;
        EventManager.returnMainMenuEvent -= LoadMainMenu;
    }

}
