using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //enum for the current game type 
    //either ‘3 Strikes’, ‘Playlist’ or ‘SinglePlay’ 
    public enum GameMode { ThreeStrikes, WholePlaylist, Singleplay }

    public GameMode gameMode;

    //boolean for game being paused. If this is set to true then other scripts will not run their update function 
    public bool isPaused { get; private set; }

    //integer for the number of lives remaining in ‘3 strikes’ mode 
    public int livesRemaining { get; private set; }

    //on enable instantiate the Event Manager, MicroGameManager, UIManager, HighScoreManager and AudioManager 
    private void OnEnable()
    {
        //instantiate EventManager
        //instantiate Microgame
        //instantiate UIManager
        //instantiate HighScoreManager
        //instantiate AudioManager
    }


    //on awake: 
    private void Awake()
    {
        //subscribe to the ‘PauseGame’ and ‘UnpauseGame’ events on EventManager 
        //subscribe to ‘QuitGame’ event on EventManager 
        //subscribe to ‘MicroGameComplete’ event on EventManager 
        EventManager.microGameCompleteEvent += MicrogameComplete;
        //subscribe to ‘SaveSettings’ event on EventManager 
    }

    //on destroy: 
    private void OnDestroy()
    {
        //unsubscribe from all events 
        EventManager.microGameCompleteEvent -= MicrogameComplete;
    }

    //method for loading in other managers
    private void LoadManagers()
    {
        //load in:
        //Event Manager 
        //MicroGameManager 
        //UIManager 
        //HighScoreManager 
        //AudioManager
    }


    //method for quitting game 
    private void QuitGame()
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


    //new game method 
    private void NewGame(int _gameMode) //takes in variable for game type 
    {
        //sets the enum variable game type based on the game type variable and then invokes the ‘NewGame’ method and pass it one of three game modes
        switch (_gameMode)
        {
            case 0:
                gameMode = GameMode.ThreeStrikes;
                livesRemaining = 3;
                //invoke NewGameStart and pass it 0 for threestrikes
                break;
            case 1:
                gameMode = GameMode.WholePlaylist;
                //invoke the NewGameStart event and pass it 1 for every game once
                break;
            case 2:
                gameMode = GameMode.Singleplay;
                //invoke the PlayOneGame event and pass it the id of the game to be played
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
            }
            else if(gameMode == GameMode.WholePlaylist) //if entire playlist
            {
                //invoke ‘UpdateHighScore’ event and invoke ‘NextGamePlaylist’ event 
            }
            else //if Freeplay:
            {
                //invoke ‘UpdateHighScore’ event and invoke ‘MainMenu’ event 
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
                    //Debug.Log("You won the game!");
                }
                else
                {
                    //No? Invoke ‘GameOver’ event
                    Debug.Log("You won the game!");
                }
            }
            else if (gameMode == GameMode.WholePlaylist) //if entire playlist
            {
                //invoke ‘NextGamePlaylist’ event 
            }
            else //if Freeplay:
            {
                //invoke ‘MainMenu’ event 
            }
        }
    }
}
