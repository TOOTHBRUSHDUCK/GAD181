using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_DestroyRain : MonoBehaviour
{
    [SerializeField] private Umbrella_RainSpawn rainSpawn;
    [SerializeField] private float despawnInterval = 1.4f;
    void Start()
    {
        
    }
    void Update()
    {
        DeSpawnRain();
    }
    public void DeSpawnRain() 
    {
        StartCoroutine(DestroyRain());
    }

    IEnumerator DestroyRain()
    {
        yield return new WaitForSeconds(despawnInterval);
        this.gameObject.SetActive(false);
        rainSpawn.spawnLimiter = false;
    }
}
