using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Chase : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent agent;
    [SerializeField] private float aggroRange;
    [SerializeField] private float distance;
  
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
    }

    void ChaseTarget()
    {
        // Set the agent to go to the currently selected target;
        agent.destination = target.position;
    }


    void Update()
    {
          if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        distance = Vector3.Distance(this.transform.position, target.position);
        if (distance <= aggroRange)
        {
            ChaseTarget();
        }
        // Choose the next destination point when the agent gets
        // close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f && distance <= aggroRange)
        //    ChaseTarget();


    }

    //void OnDisable()
    //{
    //    if (this.gameObject.activeSelf == true)
    //        agent.ResetPath();
    //}

}

