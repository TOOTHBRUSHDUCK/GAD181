using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //enum for the current game type 
    //either ‘3 Strikes’, ‘Playlist’ or ‘SinglePlay’ 
    public enum GameMode { ThreeStrikes, WholePlaylist, Singleplay }

    public GameMode gameMode { get; private set; }

    //boolean for game being paused. If this is set to true then other scripts will not run their update function 
    public bool isPaused { get; private set; }

    //integer for the number of lives remaining in ‘3 strikes’ mode 
    public int livesRemaining { get; private set; }


    //references to the prefab manager objects + scripts
    [SerializeField] GameObject eventManagerPref;
    [SerializeField] GameObject microGameManagerPref;
    [SerializeField] GameObject uiManagerPref;
    [SerializeField] GameObject highScoreManagerPref;
    [SerializeField] GameObject audioManagerPref;

    public static GameManager Instance;

    //on enable instantiate the Event Manager, MicroGameManager, UIManager, HighScoreManager and AudioManager 
    private void OnEnable()
    {
        //instantiate other managers
        LoadManagers();

        if(Instance == null)
        {
            Instance = this;
        }
    }


    //on awake: 
    private void Awake()
    {
        //subscribe to the ‘PauseGame’ and ‘UnpauseGame’ events on EventManager 
        EventManager.pauseGameEvent += PauseGame;
        EventManager.unpauseGameEvent += UnpauseGame;
        //subscribe to ‘QuitGame’ event on EventManager 
        EventManager.quitGameEvent += QuitGame;
        //subscribe to ‘MicroGameComplete’ event on EventManager 
        EventManager.microGameCompleteEvent += MicrogameComplete;
        //subscribe to ‘SaveSettings’ event on EventManager 
        EventManager.saveSettingsEvent += SaveSettings;
        //subscribe to 'loading settings' on EventManager
        EventManager.loadSettingsEvent += LoadSettings;
    }

    //on destroy: 
    private void OnDestroy()
    {
        //subscribe to the ‘PauseGame’ and ‘UnpauseGame’ events on EventManager 
        EventManager.pauseGameEvent -= PauseGame;
        EventManager.unpauseGameEvent -= UnpauseGame;
        //subscribe to ‘QuitGame’ event on EventManager 
        EventManager.quitGameEvent -= QuitGame;
        //unsubscribe from all events 
        EventManager.microGameCompleteEvent -= MicrogameComplete;
        //subscribe to ‘SaveSettings’ event on EventManager 
        EventManager.saveSettingsEvent -= SaveSettings;
        //subscribe to 'loading settings' on EventManager
        EventManager.loadSettingsEvent -= LoadSettings;
    }

    //method for loading in other managers
    private void LoadManagers()
    {
        //load in:
        //Event Manager 
        if (eventManagerPref != null)
        {
            Instantiate(eventManagerPref);
        }
        //MicroGameManager 
        if (microGameManagerPref != null)
        {
            Instantiate(microGameManagerPref);
        }
        //AudioManager
        if (audioManagerPref != null) 
        { 
            Instantiate(audioManagerPref); 
        }
        //UIManager 
        if (uiManagerPref != null)
        {
            Instantiate(uiManagerPref);
        }
        //HighScoreManager
        if (highScoreManagerPref != null)
        {
            Instantiate(highScoreManagerPref);
        }
    }

    public void LoadSettings()
    {
        //load the settings from file and plug them into the AudioManager
    }

    private void SaveSettings()
    {
        //save the settings on the 'AudioManager'
    }


    //method for quitting game 
    public void QuitGame()
    {
        Application.Quit();
    }

    private void OptionsMenu()
    {
        //method for invoking the open options UI menu event 
    }

    private void HighScoreMenu()
    {
        //method for invoking the open high score screen event 
    }

    public void PlayOneGame(int gameID)
    {
        //Debug.Log("Hi");
        gameMode = GameMode.Singleplay;
        EventManager.closeMenuEvent();
        EventManager.playOneGameEvent(gameID);
    }

    //new game method 
    public void StartPlaylist(int _gameMode) //takes in variable for game type 
    {
        //sets the enum variable game type based on the game type variable and then invokes the ‘NewGame’ method and pass it one of three game modes
        switch (_gameMode)
        {
            case 0:
                gameMode = GameMode.ThreeStrikes;
                livesRemaining = 3;
                //invoke NewGameStart and pass it 0 for threestrikes
                EventManager.newGameStartEvent(_gameMode);
                break;
            case 1:
                gameMode = GameMode.WholePlaylist;
                //invoke the NewGameStart event and pass it 1 for every game once
                EventManager.newGameStartEvent(_gameMode);
                break;            
        }
    }

    //method for pausing game and invoking the OpenPauseMenu event 
    private void PauseGame()
    {
        isPaused = true;
        //invoke the OpenPauseMenu event
    }

    //method for unpausing game and invoking ‘CloseMenus’ event 
    private void UnpauseGame()
    {
        isPaused = false;
        //invoke the CloseMenus event
        EventManager.closeMenuEvent();
    }

    //method for handling a microgame being complete 
    private void MicrogameComplete(bool win) //takes in win/lose variable 
    {        
        //if win: check the game type 
        if(win == true)
        {
            if(gameMode == GameMode.ThreeStrikes) //if it was 3 strkes and you're out
            {
                //invoke ‘UpdateHighScore’ event and invoke ‘NextGameRandom’ event
                Debug.Log("You won the game!");
                EventManager.nextGameRandomEvent();
            }
            else if(gameMode == GameMode.WholePlaylist) //if entire playlist
            {
                //invoke ‘UpdateHighScore’ event and invoke ‘NextGamePlaylist’ event 
                EventManager.nextGameWholePlaylistEvent();
            }
            else //if Freeplay:
            {
                //invoke ‘UpdateHighScore’ event and invoke ‘MainMenu’ event 
                EventManager.returnMainMenuEvent();
            }
        }
        else //if lose:  
        {
            //check the game type
            if (gameMode == GameMode.ThreeStrikes) //if it was 3 strkes and you're out
            {
                //check if lives greater than 1
                if(livesRemaining > 1)
                {
                    //Yes? Subtract 1 life and invoke ‘NextGameRandom’
                    livesRemaining--;
                    //Debug.Log("You won the game!");
                    EventManager.nextGameRandomEvent();
                }
                else
                {
                    //No? Invoke ‘GameOver’ event
                    Debug.Log("You lost the game!");
                    EventManager.returnMainMenuEvent();
                }
            }
            else if (gameMode == GameMode.WholePlaylist) //if entire playlist
            {
                //invoke ‘NextGamePlaylist’ event 
                EventManager.nextGameWholePlaylistEvent();
            }
            else //if Freeplay:
            {
                //invoke ‘MainMenu’ event 
                EventManager.returnMainMenuEvent();
            }
        }
    }
}
