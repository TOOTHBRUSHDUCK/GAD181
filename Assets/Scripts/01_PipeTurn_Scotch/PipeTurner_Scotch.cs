using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTurner_Scotch : MonoBehaviour
{
    //reference to 'positive' game object at front end
    private GameObject posNode;

    //pipe is aligned boolean variable
    private bool aligned = false;

    [SerializeField] MeshRenderer piperender;

    [SerializeField] AudioSource pipeSFXSource;

    [SerializeField] AudioClip pipeCorrectAudio;

    [SerializeField] GameObject particle1;
    [SerializeField] GameObject particle2;
       

    private void Awake()
    {
        //find a child object tagged with 'pipe_Positive' and set it to be the posNode
        foreach (Transform child in transform)
        {
            if (child.tag == "pipe_Positive")
            {
                posNode = child.gameObject;
            }
        }
        if(posNode == null)
        {
            Debug.LogError("You need to have a child object with the pipe_Positive tag!");
        }        
    }

    private void Start()
    {
        if(particle1 != null)
        {
            particle1.SetActive(false);
        }
        if(particle2 != null)
        {
            particle2.SetActive(false);
        }

        //subscribe to the pipecheckevent
        EventManager.pipeCheckEvent += SetAligned;
    }

    /* private void Update()
     {
         //placeholder input for testing
         /*if (Input.GetKeyDown(KeyCode.A))
         {
             turnPipe(0);
         }
         else if (Input.GetKeyDown(KeyCode.D))
         {
             turnPipe(1);
         }
     }*/

    //pipe turning method
    //takes in input variable 'left' or 'right' and turns the pipe accordingly
    public void TurnPipe(int dir)
    {
        //the currently active pipe will rotate 90 degrees left or right depending on input variable
        if (dir == 0)
        {
            transform.eulerAngles += new Vector3(0, -90, 0);
        }
        else if (dir == 1)
        {
            transform.eulerAngles += new Vector3(0, 90, 0);
        }
        
    }

    private void SetAligned()
    {
        //the pipe will send out a raycast 'forward' from the positive node
        RaycastHit hit;
        Physics.Raycast(posNode.transform.position, posNode.transform.forward, out hit, 5f);

        
        if (hit.collider != null) 
        {
            //if the raycast hits a collider with the 'pipe_Negative' then set the pipe aligned bool to true
            if (hit.collider.tag == "pipe_Negative")
            {
                if(particle1 != null)
                {
                    particle1.SetActive(true);
                }
                if(particle2 != null)
                {
                    particle2.SetActive(true);
                }
                //play the aligned pipe audio and turn on the particle effect for this pipe
                if (aligned != true)
                {
                    pipeSFXSource.PlayOneShot(pipeCorrectAudio);
                }
                aligned = true;
                //Debug.Log(name + " is aligned!");
            }
            //if the raycast doesn't hit a 'pipe_Negative' collider then set the pipe to negativ
            else if (hit.collider.tag != "pipe_Negative") 
            {
                if (particle1 != null)
                {
                    particle1.SetActive(false);
                }
                if (particle2 != null)
                {
                    particle2.SetActive(false);
                }
                aligned = false;
                //Debug.Log(name + " is not aligned!");
            } 
        }
        else
        {
            if (particle1 != null)
            {
                particle1.SetActive(false);
            }
            if (particle2 != null)
            {
                particle2.SetActive(false);
            }
            aligned = false;
            //Debug.Log(name + " is not aligned!");
        }
    }

    //check if pipe is aligned method:
    //return true or false based on aligned variable
    public bool CheckAligned()
    {
        if (aligned)
        {
            
            return true;

        }
        else
        {
            return false;
        }
    }

    private void OnDestroy()
    {
        EventManager.pipeCheckEvent -= SetAligned;
    }

}
