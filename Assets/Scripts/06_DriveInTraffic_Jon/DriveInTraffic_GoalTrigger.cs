using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveInTraffic_GoalTrigger : MonoBehaviour
{
    [SerializeField] public bool reachGoal;
    void Start()
    {
        reachGoal = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            reachGoal = true;
        } 
    }
}
