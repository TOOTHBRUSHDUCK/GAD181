using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveInTraffic_TriggerParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem impactMetal;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacles")
        {
            impactMetal.Play();
        }    
    }

}
