using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_HoldButt : MonoBehaviour
{
    //This covers: Press a button in a window of time, hold a button for a duration, do nothing for a timer, etc.
    //All time considered in engine ticks, ie FixedUpdate ticks. 50 occur a second, so 50 = 1s
    [SerializeField] protected int initialWait; //Initial time where pressing a key will not succeed.
    [SerializeField] protected int endWait; //Time at end where input will not succeed
    [SerializeField] protected int timeLimit; //What is the time limit for the game? This should match the timer script
    [SerializeField] protected string desiredInput; //what should be held
    [SerializeField] protected int desiredHold; //How long should it be held? Put 1 to just check for any amount
    [SerializeField] protected bool failEarly; //Will the player fail for pressing button early?
    [SerializeField] protected bool failLate; //Will the player fail for pressing button late?
    [SerializeField] protected bool failTime; //Will the player fail for the timer running out?
    [SerializeField] protected bool resetHoldOnRelease; //Is the hold timer reset on releasing the key early?
    [SerializeField] protected int score; //How much score player will gain

    private protected int timer = 0; //tick up by 1 every fixed update
    [SerializeField] private protected int heldTime = 0; //How long input held at correct time
    [SerializeField] private protected bool gameEnded; //has the game ended yet. Used for if things happen after game end
    private protected bool isHeld = false; //is the desired input currently being held

    void Update() //Update is purely used to check for the desired input, and sets a bool to true while it's held
    {
        if(Input.GetKey(desiredInput))
        {
            isHeld = true;
        }
        else
        {
            isHeld = false;
        }
    }

    void FixedUpdate() //Fixed update is where main thing get's called, and timer ticks up.
    {
        CheckHold();
        timer++;
    }

    public virtual void CheckHold() //Meat of this parent class
    {
        if(timer >= timeLimit) //Make sure not overtime, if you are, then using the appropriate ending.
        {
            if(failTime && heldTime < desiredHold)
            {
                Fail();
            }
            else
            {
                Win();
            }
        }
        if(isHeld) //Very simple, while holding the input tick up the hold time, or fail if it's too early or late and meant to
        {
            if(timer >= initialWait && timer <= (timeLimit - endWait))
            {
                heldTime++;
                DoOnHold();
            }
            else if(timer < initialWait && failEarly)
            {
                Fail();
            }
            else if(timer > (timeLimit - endWait) && failLate)
            {
                Fail();
            }
        }
        else if(resetHoldOnRelease) //Actually reset the held time if told to reset the held time
        {
            heldTime = 0;
        }
        if(heldTime >= desiredHold) //main win call :O
        {
            Win();
        }
    }

    public virtual void DoOnHold()
    {
        //Fill in in inheritors
        this.transform.localScale += new Vector3(0.01f,0.01f,0.01f);
    }

    public virtual void Fail()
    {
        //call fail event
        Debug.Log("Fail");
    }

    public virtual void Win()
    {
        //call win event
        Debug.Log("Win");
    }
}