using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroGameManager : MonoBehaviour
{
    //variable for setting up this script as a singleton
    public static MicroGameManager Instance;

    //list of integers for storing the current 'playlist'
    [SerializeField] private List<int> currentPlaylist = new List<int>();

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
    }

    private void Start()
    {
        //in the start function subscribe to the following events:
        //NextGameRandom

        //NextGameWholePlaylist
        //ReturnMainMenu
        EventManager.returnMainMenuEvent += CloseMicroGame;
        //PlayOneGame

        GenerateRandomGameList();
    }



    //method for launching a microgame, taking in an integer variable to match up with the microgame's position in the scene index
    //this also update the 'current microgame' integer
    private void LaunchMicroGame(int gameIndex)
    {
        SceneManager.LoadScene(gameIndex, LoadSceneMode.Additive);
    }

    //method for closing a microgame (unloading the scene) taking in an integer for the 'current microgame'
    private void CloseMicroGame()
    {
        SceneManager.UnloadSceneAsync(currentGameIndex);
    }

    //method for generating a random list of microgames from all microgame indexes
    private void GenerateRandomGameList()
    {

        for(int x = 0; x < allMicroGames.Count; x++)
        {
            int ran = Random.Range(0, allMicroGames.Count);
            if (!currentPlaylist.Contains(ran))
            {
                currentPlaylist.Add(ran);
            }
            else
            {
                x--;
                if(x < 0)
                {
                    x = 0;
                }
            }
        }
    }

    //method for generating a list of microgames in the default order

    
    private void OnDestroy()
    {
        //when this object is destroyed unscubscribe from all events
    }
}
