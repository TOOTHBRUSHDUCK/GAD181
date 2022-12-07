using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MB_Mourn_Wife_1 : MB_HoldButt
{
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject leg;
    [SerializeField] private GameObject igor;
    [SerializeField] private GameObject mainFlower;
    [SerializeField] private GameObject flowerBox;

    public override void DoOnHold()
    {
        if(heldTime == 1)
        {
            //Reset Igor here
            rightIgor();
            flower = Instantiate(mainFlower, (igor.transform.position + new Vector3(1f,0f,1.2f)), Quaternion.identity, flowerBox.transform);
            //SceneManager.MoveGameObjectToScene(flower, SceneManager.GetSceneByName("MB_Mourn_Wife_1"));
            //rightIgor();
        }
        else if(heldTime > 1 && heldTime <= desiredHold)
        {
            igor.transform.position = new Vector3((3f / desiredHold), 0f, 0f) + igor.transform.position;
            transform.rotation *= Quaternion.AngleAxis((1f * 50 / desiredHold), Vector3.up);
            arm.transform.localRotation *= Quaternion.AngleAxis((-0.8f * 50 / desiredHold), Vector3.up);
            arm.transform.localPosition += new Vector3((0.01f * 50 / desiredHold), 0f, (0.01f * 50 / desiredHold));
            if(heldTime < 25)
            {
                flower.transform.position += new Vector3((0.02f * 50 / desiredHold) + (3f / desiredHold),0f,(0.001f * 50 / desiredHold));
            }
            else
            {
                flower.transform.position += new Vector3((0.02f * 50 / desiredHold) + (3f / desiredHold),0f,(-0.0075f * 50 / desiredHold));
            }
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
        else if(resetHoldOnRelease && gameEnded == false) //Actually reset the held time if told to reset the held time
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
        igor.transform.position = new Vector3(-4f, 5f, -1f);
        transform.rotation = Quaternion.identity;
        arm.transform.rotation = Quaternion.identity;
        leg.transform.rotation = Quaternion.identity;
    }

    private void wrongIgor()
    {
        transform.rotation = Quaternion.identity * Quaternion.AngleAxis(90, Vector3.up);
        arm.transform.localRotation = Quaternion.identity * Quaternion.AngleAxis(-90, Vector3.up);
        arm.transform.localPosition = new Vector3(-0.1f, 0f, 0.5f);
        leg.transform.rotation = Quaternion.identity * Quaternion.AngleAxis(90, Vector3.up);
        flower.transform.position = new Vector3(flower.transform.position.x,flower.transform.position.y + Random.Range(-0.50f,0.50f),-1f);
        flower.transform.rotation *= Quaternion.AngleAxis(Random.Range(-40f,40f), Vector3.up);
    }

    public override void Win()
    {
        gameEnded = true;
        flower.transform.position = new Vector3(flower.transform.position.x,flower.transform.position.y,-0.3f);
        //call win event
        Debug.Log("Win");
        //Application.Quit();
        //EventManager.microGameCompleteEvent(true);
        //UnityEditor.EditorApplication.isPlaying = false;
        Invoke("EndWin", 1f);
        
    }
}
