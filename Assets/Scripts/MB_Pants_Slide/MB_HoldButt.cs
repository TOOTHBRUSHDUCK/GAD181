using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_HoldButt : MonoBehaviour
{
    //This covers: Press a button in a window of time, hold a button for a duration, do nothing for a timer, etc.
    //All time considered in engine ticks, ie FixedUpdate ticks. 50 occur a second, so 50 = 1s
    [SerializeField] int initialWait; //Initial time where pressing a key will not succeed.
    [SerializeField] int endWait; //Time at end where input will not succeed
    [SerializeField] int timeLimit; //What is the time limit for the game? This should match the timer script
    [SerializeField] string desiredInput; //what should be held
    [SerializeField] int desiredHold; //How long should it be held? Put 1 to just check for any amount
    [SerializeField] bool failEarly; //Will the player fail for pressing button early?
    [SerializeField] bool failLate; //Will the player fail for pressing button late?
    [SerializeField] bool failTime; //Will the player fail for the timer running out?
    [SerializeField] bool resetHoldOnRelease; //Is the hold timer reset on releasing the key early?
    [SerializeField] int score; //How much score player will gain

    private int timer = 0; //tick up by 1 every fixed update
    [SerializeField] private int heldTime = 0; //How long input held at correct time
    [SerializeField] private bool gameEnded; //has the game ended yet. Used for if things happen after game end
    private bool isHeld = false; //is the desired input currently being held

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
        if(timer >= timeLimit) //Make sure not overtime, if you are, thend using the appropriate ending.
        {
            if(failTime)
            {
                Fail();
            }
            else
            {
                Win();
            }
        }
        if(isHeld)
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
        else if(resetHoldOnRelease)
        {
            heldTime = 0;
        }
        if(heldTime >= desiredHold)
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