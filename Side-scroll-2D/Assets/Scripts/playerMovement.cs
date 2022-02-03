using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D _controller;
    private float horizontalMove = 0f;
    public  float horizontlalSpeed; 
    private bool jump=false; 
    private bool crouch=false;
   
    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * horizontlalSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
        crouch = Input.GetButton("Crouch");
        

        if(crouch == true)
        {
            Debug.Log("crouch true");
        }
        else if(crouch == false)
        {
            Debug.Log("crouch false");
        }

        if(jump == true)
        {
            Debug.Log("jump true");
        }
        else if(jump == false)
        {
            Debug.Log("jump false");
        }
        
    }
    void FixedUpdate()
    {
        _controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
}
