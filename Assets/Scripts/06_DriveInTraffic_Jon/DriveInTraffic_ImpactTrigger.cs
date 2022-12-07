using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveInTraffic_ImpactTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem impactMetal;
    [SerializeField] private ParticleSystem OnFire;
    [SerializeField] private ParticleSystem OnSmoke;
    [SerializeField] private AudioSource carImpactAudio;
    [SerializeField] public int initialCarHP = 8;
    
    void Start()
    {

    }
    void Update() 
    {
        CarOnSmoke();
        CarOnFire();
        UpdateHP_UI();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacles")
        {
            impactMetal.Play();
            carImpactAudio.Play();
            initialCarHP -= 1;
        }    
    }
    private void CarOnSmoke()
    {
        if(initialCarHP <= 6)
        {
            OnSmoke.Play();
        }
    }
    private void CarOnFire()
    {
        if(initialCarHP <= 2)
        {
            OnFire.Play();
        }
    }
    void UpdateHP_UI()
    {
        EventManager.updateUITextEvent(3, "Car Shield:   " + (int)initialCarHP);
    }
}
