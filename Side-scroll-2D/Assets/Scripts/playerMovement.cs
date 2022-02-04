using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D _controller;
    public Animator _animator;
    private float horizontalMove = 0f;
    public  float horizontlalSpeed; 
    public bool jump=false; 
    public bool crouch=false;
    public bool isMoving = false;
   
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * horizontlalSpeed;

        if(Input.GetButtonDown("Jump") && _controller.m_Grounded)
        {
            jump = true;
        }
        
        crouch = Input.GetButton("Crouch");

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ||Input.GetKey(KeyCode.LeftArrow) )
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        

        if(crouch == true)
        {
            Debug.Log("crouch true");
        }
        else if(crouch == false)
        {
            Debug.Log("crouch false");
        }

        Debug.Log(isMoving);

        _animator.SetBool("isMoving",isMoving);
        _animator.SetBool("jump",jump);
        _animator.SetBool("grounded",_controller.m_Grounded);

    }
    void FixedUpdate()
    {
        _controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
        
    }
}
