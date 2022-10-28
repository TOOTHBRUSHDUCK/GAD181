using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class IB_PipeTurn_PipeManager : MonoBehaviour
{
    //variable referencing the text on the UI
    [SerializeField] TMP_Text timerText;

    //current pipe variable
    private IB_PipeTurn_PipeTurner currentPipe;

    //reference to material of the current pipe
    private MeshRenderer pipeRenderer;

    //references to the materials to be used for a selected pipe vs a non-selected pipe
    [SerializeField] Material currentPipeMat;
    [SerializeField] Material normPipeMat;

    //list of all pipes
    [SerializeField] private List<IB_PipeTurn_PipeTurner> pipeTurners = new List<IB_PipeTurn_PipeTurner>();

    //integer to track the index of the current pipe
    private int pipeIndex;    

    //the variable for the singleton
    public static IB_PipeTurn_PipeManager instance;

    //float for timer
    private float timer;

    private void OnEnable()
    {
        //set up the singleton for this manager
        if(instance == null)
        {
            instance = this;
        }        

        //set the initial value for the timer
        timer = 10f;
    }

    private void Awake()
    {
        //compile a list of game objects tagged with pipe so that different layouts can be used without being hardcoded/set up with this game manager in the inspetor manually
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Pipe");
        for(int i = 0; i < gameObjects.Length; i++)
        {
            if(gameObjects[i].TryGetComponent<IB_PipeTurn_PipeTurner>(out currentPipe))
            {
                pipeTurners.Add(currentPipe);
            }
        }
    }

    private void Start()
    {
        //assigning the pipe object which will be selected on start up as the first pipe in the list of all pipes, and setting the index value used elsewhere to match it
        currentPipe = pipeTurners[0];
        pipeIndex = 0;
        //setting the material of the current pipe to be the 'selected' material
        pipeRenderer = currentPipe.GetComponent<MeshRenderer>();    
        pipeRenderer.material = currentPipeMat;
    }

    //on update
    private void Update()
    {
        //on each frame decrease the time remaining by deltatime and udpate the UI
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time Remaining: " + (int)timer;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            currentPipe.TurnPipe(0);
            Invoke("CheckPipes", 1f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentPipe.TurnPipe(1);
            Invoke("CheckPipes", 1f);
        }

        //check for player input to switch pipes and call the 'switch pipe' method
        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchPipe(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchPipe(1);
        }
        
        //call the 'check if all pipes are aligned' method
        if(PipeTurnWinCheck() == true)
        {
            //Debug.Log("You win the game!");
            EventManager.microGameCompleteEvent(true);
            
        }
        else if(PipeTurnWinCheck() == false && timer <= 0)
        {
            //Debug.Log("You lost the game!");
            EventManager.microGameCompleteEvent(false);
        }      
        
    }


    //boolean method for checking if all pipes are aligned
    private bool PipeTurnWinCheck()
    {
        //Debug.Log("I'm working");
        //iterate through all pipes in list of pipes and call the 'check aligned' method
        for (int i = 0; i < pipeTurners.Count; i++)
        {
            if (pipeTurners[i].CheckAligned() == false)
            {
                //Debug.Log("Not all pipes aligned");
                return false;
            }            
        }
        //Debug.Log("All pipes aligned");
        return true;        
        //if none of the pipes return false: return true on this method
    }

    //intermediary method to allow us to invoke the pipeCheckEvent with a delay elswhere
    private void CheckPipes()
    {
        EventManager.pipeCheckEvent();
    }

    //pipe switching method
    //takes in input variable up or down
    private void SwitchPipe(int dir)
    {
        pipeRenderer.material = normPipeMat;
        //if the input is up: check if the currently selected pipe is at index 0 in pipe list
        if (dir == 0)
        {
            //if it is at 0 then switch currently selected pipe to pipe at last index in the pipe list
            if(currentPipe == pipeTurners[0])
            {
                
                currentPipe = pipeTurners.Last();
                pipeIndex = pipeTurners.Count() -1;
                

            }
            //otherwise switch the currently selected pipe to the pipe list current pipe's index - 1
            else
            {                
                pipeIndex--;
                currentPipe = pipeTurners[pipeIndex];                
            }
        }
        //if the input is down: check if the currently selected pipe is at the last index in the pipe list
        else if(dir == 1)
        {
            //if it is at the last index in the list then switch the currently selected pipe to the pipe at index 0
            if (pipeIndex == pipeTurners.Count() - 1)
            {                
                currentPipe = pipeTurners[0];
                pipeIndex = 0;
              
            }
            //otherwise switch the currently selected pipe to the pipe which is at the current pipe's index - 1
            else
            {
                
                pipeIndex++;
                currentPipe = pipeTurners[pipeIndex];
               
            }
        }
        //once the pipe has switched, update the piperenderer variable to be the meshrenderer on the current pipe then change it's material
        pipeRenderer = currentPipe.GetComponent<MeshRenderer>();
        pipeRenderer.material = currentPipeMat;
    }
}