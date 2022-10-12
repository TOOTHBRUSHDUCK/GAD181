using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IB_PipeTurn_PipeManager : MonoBehaviour
{
    //current pipe variable
    private IB_PipeTurn_PipeTurner currentPipe;

    //list of all pipes
    [SerializeField] private List<IB_PipeTurn_PipeTurner> pipeTurners = new List<IB_PipeTurn_PipeTurner>();

    //integer to track the index of the current pipe
    private int pipeIndex;

    private void Awake()
    {
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
        currentPipe = pipeTurners[0];
        pipeIndex = 0;
    }

    //on update
    private void Update()
    {
        //check for player input to turn pipes and invoke the 'turn pipe' event
        //check for player input to switch pipes and call the 'switch pipe' method
        //call the 'check if all pipes are aligned' method

        //boolean method for checking if all pipes are aligned
        //iterate through all pipes in list of pipes and call the 'check aligned' method
        //if one of the pipes returns false: return false on this method
        //if none of the pipes return false: return true on this method
    }



    //pipe switching method
    //takes in input variable up or down
    private void SwitchPipe(int dir)
    {
        //if the input is up: check if the currently selected pipe is at index 0 in pipe list
        if(dir == 0)
        {
            //if it is at 0 then switch currently selected pipe to pipe at last index in the pipe list
            if(currentPipe = pipeTurners[0])
            {
                currentPipe = pipeTurners.Last();
                pipeIndex = pipeTurners.Count();
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
            if (currentPipe == pipeTurners.Last())
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
    }

}
