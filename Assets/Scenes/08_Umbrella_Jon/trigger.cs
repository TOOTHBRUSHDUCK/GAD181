using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other) 
    {   
        if(other.tag == "Player")
        {   
            other.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("You have hit the player");
        }
    }
}
