using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Code written by Ian 'Scotch' Bell for GAD181 Brief 1/2/3 at SAE Institute Perth 22T3
 * In collaboration with: Michael Bzdyl, John Min Wong, Felix Speller and Matt Hopkins 
 * 
 * This script simply contains all delegates & events which the game 'Make the Snake' will require for its full functionality
 * The script operates as a singleton and as such only one should be present in the scene at one time.
 */

public class EventManager : MonoBehaviour
{
    //static event manager variable for the singleton
    public static EventManager Instance;

    //on enable assign the singleton as this object
    private void OnEnable()
    {
        //check if a static eventmanager hasn't already been created
        if (Instance == null)
        {
            //assign this object as the instance
            Instance = this;
        }
        else
        {
            //in the event instance is not null there is already an event manager and an error should be logged for debugging.
            Debug.LogError("There should only be one EventManager in the scene!");
        }
    }



    //Delegates and events

    //NewGameStart taking in an integer for determining the game type to be loaded
    public delegate void NewGameStart(int gameMode);
    public static NewGameStart newGameStartEvent;

    //PlayOneGame for playing a specific game, takes an integer for the scene index OR a string for the scene name
    public delegate void PlayOneGame(int gameIndex);
    public static PlayOneGame playOneGameEvent;

    //PauseGame event
    public delegate void PauseGame();
    public static PauseGame pauseGameEvent;

    //UnpauseGame event
    public delegate void UnpauseGame();
    public static UnpauseGame unpauseGameEvent;

    //OpenPauseMenu event
    public delegate void OpenPauseMenu();
    public static OpenPauseMenu openPauseMenuEvent;

    //CloseMenus event (closes any menus which are currently open such as the main pause menu and settings/options menu)
    public delegate void CloseMenus();
    public static CloseMenus closeMenuEvent;

    //OpenHighScoreScreen event (possibly ENTIRELY UNNECESSARY since this will just be a function which happens within the main menu and can probably just be handled through the button event system instead
    public delegate void OpenHighScoreScreen();
    public static OpenHighScoreScreen openHighScoreScreenEvent;

    //OpenOptionsMenu
    public delegate void OpenOptionsMenu();
    public static OpenOptionsMenu openOptionsMenuEvent;

    //MicroGameComplete event taking in a bool of true or false
    public delegate void MicroGameComplete(bool winOrLose);
    public static MicroGameComplete microGameCompleteEvent;

    //NextGameRandom event
    public delegate void NextGameRandom();
    public static NextGameRandom nextGameRandomEvent;

    //NextGameSinglePlay
    public delegate void NextGameWholePlaylist();
    public static NextGameWholePlaylist nextGameWholePlaylistEvent;

    //ReturnMainMenu event
    public delegate void ReturnMainMenu();
    public static ReturnMainMenu returnMainMenuEvent;

    //UpdateHighScore taking in an integer for the game index and the score from that game
    public delegate void UpdateHighScore(int gameIndex, int gameScore);
    public static UpdateHighScore updateHighScoreEvent;

    //ThreeStrikesGameOver event for when the player loses their last life in three strikes and out mode
    public delegate void ThreeStrikesGameOver();
    public static ThreeStrikesGameOver threeStrikesGameOverEvent;

    //delegant and event for quitting the game
    public delegate void QuitGame();
    public static QuitGame quitGameEvent;

    //delegate + event for saving settings
    public delegate void SaveSettings();
    public static SaveSettings saveSettingsEvent;


    //delegate + event for loading settings
    public delegate void LoadSettings();
    public static LoadSettings loadSettingsEvent;

}
