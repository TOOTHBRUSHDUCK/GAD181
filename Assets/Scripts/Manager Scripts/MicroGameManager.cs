using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroGameManager : MonoBehaviour
{
    //variable for setting up this script as a singleton
    public static MicroGameManager Instance;

    //list of integers for storing the current 'playlist'
    [SerializeField] private List<int> randomPlaylist = new List<int>();

    [SerializeField] private List<int> allMicroGames = new List<int>();

    //integer for storing what the index of the current microgame being played is
    private int currentGameIndex;    

    [SerializeField] int microGameCount;




    private void OnEnable()
    {
        //on enable check if there is a singleton already; if not, make this the singleton.
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            //if there is one then destroy this object
            Destroy(gameObject);
        }        

        //PLACEHOLDER FOR TESTING        
    }


    private void Awake()
    {
        
    }


    private void Start()
    {
        //subscribe to the PlayOneGame event
        EventManager.playOneGameEvent += LaunchMicroGame;
        //subscribe to the StartGame event
        EventManager.newGameStartEvent += LaunchPlaylist;
        //in the start function subscribe to the following events:
        //NextGameRandom
        EventManager.nextGameRandomEvent += NextGameRandom;
        //NextGameWholePlaylist
        EventManager.nextGameWholePlaylistEvent += NextGameWholePlayList;
        //ReturnMainMenu
        EventManager.returnMainMenuEvent += CloseMicroGame;

        //PLACEHOLDER FOR TESTING
        //GenerateRandomGameList();
    }



    //method for launching a microgame, taking in an integer variable to match up with the microgame's position in the scene index
    //this also update the 'current microgame' integer
    private void LaunchMicroGame(int gameIndex)
    {
        SceneManager.LoadScene(gameIndex, LoadSceneMode.Additive);      
        if(GameManager.Instance.gameMode == GameManager.GameMode.Singleplay)
        {
            currentGameIndex = gameIndex;
        }
        EventManager.togglePauseButtonMenuEvent(true);
    }

    private void LaunchPlaylist(int playList)
    {
        if(playList == 0) //this will be for random three strikes mode
        {
            EventManager.closeMenuEvent(); //close any open menus
            GenerateRandomGameList(); //create the initial random playlist
            currentGameIndex = 0; //set the currentGameIndex to be 0
            LaunchMicroGame(randomPlaylist[currentGameIndex]);
            Debug.Log("Launching Microgame " + randomPlaylist[currentGameIndex]);
        }
        if(playList == 1) //launch the whole playlist mode
        {
            EventManager.closeMenuEvent(); //close any open menus
            currentGameIndex = 0; //set the current game index to be zero
            LaunchMicroGame(allMicroGames[currentGameIndex]);
            Debug.Log("Launching Microgame " + allMicroGames[currentGameIndex]);
        }
    }

    //method for closing a microgame (unloading the scene) taking in an integer for the 'current microgame'
    private void CloseMicroGame()
    {
        EventManager.togglePauseButtonMenuEvent(false);
        if (GameManager.Instance.gameMode == GameManager.GameMode.ThreeStrikes)
        {
            SceneManager.UnloadSceneAsync(randomPlaylist[currentGameIndex]);
        }
        else if(GameManager.Instance.gameMode == GameManager.GameMode.WholePlaylist)
        {
            SceneManager.UnloadSceneAsync(allMicroGames[currentGameIndex]);
        }
        else
        {
            SceneManager.UnloadSceneAsync(currentGameIndex);
        }
    }

    //method for generating a random list of microgames from all microgame indexes
    private void GenerateRandomGameList()
    {        
        randomPlaylist.Clear();    
        currentGameIndex = 0;

        //temporary list equal to regular list
        List<int> tempPlaylist = new List<int>();
        //add all the microgames to the temporary playlist
        tempPlaylist.AddRange(allMicroGames);

        //iterate a number of times equal to the allMicroGames list
        for(int x = 0; x < allMicroGames.Count; x++)
        {
            int ran = Random.Range(0, tempPlaylist.Count); //generate random number between 0 and length of temporary playlist
            //add the randomly selected micrograme to the random list
            randomPlaylist.Add(tempPlaylist[ran]);
            //remove the randomly selected microgame from the temporary list
            tempPlaylist.RemoveAt(ran);
        }
               
            
        //deprecated bad algorithm, keeping for reference - Scotch
        /*for(int x = 0; x < allMicroGames.Count; x++)
        {
            int ran = Random.Range(0, allMicroGames.Count);
            ran++;
            if (!randomPlaylist.Contains(ran))
            {
                randomPlaylist.Add(ran);
            }
            else
            {
                x--;
                if(x < 0)
                {
                    x = 0;
                }
            }
        }*/
    }

    private void NextGameRandom()
    {
        CloseMicroGame();
        //check if the game currently being played is the last one in the entire list of random games
        if (currentGameIndex < randomPlaylist.Count - 1) 
        {
            //increase the index of the current microgame by one
            currentGameIndex++;
            Debug.Log(currentGameIndex);
            //launch the next microgame in that list
            LaunchMicroGame(randomPlaylist[currentGameIndex]);
        }
        else
        {
            //re-scramble the list of microgames
            GenerateRandomGameList();

            currentGameIndex = 0;
            LaunchMicroGame(randomPlaylist[currentGameIndex]);
        }
    }

    private void NextGameWholePlayList()
    {
        CloseMicroGame();
        if(currentGameIndex < allMicroGames.Count - 1)
        {
            currentGameIndex++;
            LaunchMicroGame(allMicroGames[currentGameIndex]);
        }
        else
        {
            EventManager.returnMainMenuEvent();
        }
    }

    
    private void OnDestroy()
    {
        //when this object is destroyed unscubscribe from all events
        //subscribe to the PlayOneGame event
        EventManager.playOneGameEvent -= LaunchMicroGame;
        //subscribe to the StartGame event
        EventManager.newGameStartEvent -= LaunchPlaylist;
        //in the start function subscribe to the following events:
        //NextGameRandom
        EventManager.nextGameRandomEvent -= NextGameRandom;
        //NextGameWholePlaylist
        EventManager.nextGameWholePlaylistEvent -= NextGameWholePlayList;
        //ReturnMainMenu
        EventManager.returnMainMenuEvent -= CloseMicroGame;
    }
}
