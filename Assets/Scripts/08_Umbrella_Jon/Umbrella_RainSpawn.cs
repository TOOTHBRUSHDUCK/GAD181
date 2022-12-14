using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_RainSpawn : MonoBehaviour
{
    private int rollResult;
    [SerializeField] float spawnInterval = 2.5f;
    [SerializeField] GameObject upRain;
    [SerializeField] GameObject downRain;
    [SerializeField] GameObject leftRain;
    [SerializeField] GameObject rightRain;
    public bool spawnLimiter = false;
    void Start()
    {
        StartRainSpawn();
    }

    void Update()
    {
        if(GameManager.Instance.isPaused==false)
        {
            StartRainSpawn();
        }
        else
        {
            CancelRainSpawn();
        }
    }
    private void RollRain()
    {
        rollResult = Random.Range(0,7);
        if(rollResult <= 1 && spawnLimiter == false)
        {
            upRain.SetActive(true);
            spawnLimiter = true;
        }
        else if (rollResult >1 && rollResult<=3 && spawnLimiter == false)
        {
            downRain.SetActive(true);
            spawnLimiter = true;
        }
        else if (rollResult >3 && rollResult<=5 && spawnLimiter == false)
        {
            leftRain.SetActive(true);
            spawnLimiter = true;
        }
        else if (rollResult >5 && rollResult<=7 && spawnLimiter == false)
        {
            rightRain.SetActive(true);
            spawnLimiter = true;
        }
    }
    private void StartRainSpawn()
    {
        InvokeRepeating("RollRain", 0.0f, spawnInterval);  
    }

    public void CancelRainSpawn()
    {
        CancelInvoke("RollRain");
    }
}
