using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Pant_Manager : MB_HoldButt
{
    
    public override void DoOnHold()
    {
        //If the game is not yet won, the pants will slide up. Timed such that they stop when equipped by the leg
        if(heldTime <= desiredHold)
        {
            this.transform.position += new Vector3(0,0,0.111f);
        }
    }
}
