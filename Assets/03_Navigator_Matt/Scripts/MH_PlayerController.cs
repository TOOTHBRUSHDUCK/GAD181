using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_PlayerController : MonoBehaviour
{
    public Rigidbody igorRB;
    public float moveSpeed;

    private Vector2 moveInput;

    public Animator animator;

    public SpriteRenderer theSR;

    private bool movingUp;

    private bool movingDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        igorRB.velocity = new Vector3(moveInput.x * moveSpeed, igorRB.velocity.y, moveInput.y * moveSpeed);


        animator.SetFloat("moveSpeed", igorRB.velocity.magnitude);
    

        if(!theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = true;
        }
        else if(theSR.flipX && moveInput.x >0)
        {
            theSR.flipX = false;
        }

        if(!movingUp && moveInput.y > 0)
        {
            movingUp = true;
        }
        else if(!movingUp && moveInput.y < 0)
        {
            movingUp = false;
        }
        animator.SetBool("movingUp", movingUp);
    }
}
