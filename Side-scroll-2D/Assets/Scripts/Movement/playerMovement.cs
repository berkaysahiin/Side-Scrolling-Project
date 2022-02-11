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
    public playerAttackManager _pam;
   
    void Start()
    {
        
    }

    void Update()
    {
        
            if(!_pam._flying.isFlying && !_pam._playerPowerShot.powerShot && !_pam._playerBasicShot.basicShot)
            {
                horizontlalSpeed = 32; 
            }
            else
            {
                horizontlalSpeed = 0;
            }

            horizontalMove = Input.GetAxisRaw("Horizontal") * horizontlalSpeed;  

            if(Input.GetButtonDown("Jump") && _pam.globalCooldown <= 0 && ! _pam._flying.isFlying && !_pam._playerPowerShot.powerShot && !_pam._playerBasicShot.basicShot )
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
        
    _pam._anim.SetBool("isMoving",isMoving);
    _pam._anim.SetBool("jump",jump);
    _pam._anim.SetBool("grounded",_pam._char.m_Grounded);

    }

    void FixedUpdate()
    {
        _controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
        
    }
}
