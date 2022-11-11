using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Navigator : MonoBehaviour
{
    // this is the players move speed
    public float moveSpeed = 100f;

    // Update is called once per frame
    void Update()
    {

        // Move player via WASD keys
        if (Input.GetKey(KeyCode.W) == true) { this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S) == true) { this.transform.position -= this.transform.forward * moveSpeed * Time.deltaTime; }

        if (Input.GetKey(KeyCode.D) == true) { this.transform.position += this.transform.right * moveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A) == true) { this.transform.position -= this.transform.right * moveSpeed * Time.deltaTime; } 
    }

    // Calls the quit game function when the player makes contact with either of the two walls
    private void OnTriggerEnter(Collider collision)
    {
     if (collision.CompareTag("Green Wall"))
        {
            Debug.Log("Win");
            QuitGame();
        }
    }
     //Call this to quit the game when in the editor (NOTE: this will not work if you build the executable)
    void QuitGame() 
    {
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
