using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Mourn_Wife_1 : MB_HoldButt
{
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject leg;

    public override void DoOnHold()
    {
        if(heldTime == 1)
        {
            //Reset Igor here
            rightIgor();
        }
        else if(heldTime > 1 && heldTime <= desiredHold)
        {

        }
    }

    public override void CheckHold() //Meat of this parent class. Significantly less used in Mashers, but still checks for losing the game.
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
            if(timer >= initialWait && timer <= (timeLimit - endWait) && !mash)
            {
                heldTime++;
                DoOnHold();
            }
            else if(timer < initialWait && failEarly) //can still fail early or late in a masher
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
            if(heldTime > 0)
            {
                wrongIgor();
            }
            heldTime = 0;
            
        }
        if(heldTime >= desiredHold) //main win call :O
        {
            Win();
        }
    }

    private void rightIgor()
    {
        transform.rotation = Quaternion.identity;
        arm.transform.rotation = Quaternion.identity;
        leg.transform.rotation = Quaternion.identity;
    }

    private void wrongIgor()
    {
        transform.rotation = Quaternion.identity * Quaternion.AngleAxis(90, Vector3.up);
        arm.transform.localRotation = Quaternion.identity * Quaternion.AngleAxis(-90, Vector3.up);
        leg.transform.rotation = Quaternion.identity * Quaternion.AngleAxis(90, Vector3.up);
    }
}
