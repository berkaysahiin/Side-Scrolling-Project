using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerPowershot : MonoBehaviour
{
    public CharacterController2D cont;
    public playerMovement mov;
    public Animator anim;
    private float PowerShotCd;
    private float PowerShotStartCd = 3.0f;
    private float PowerShotChargeTimer = 2.0f;
    private float PowerShotStartChargeTimer;
    private bool PowerShotChargeReady=true;
    private bool PowerShotCharging=false;
    private bool PowerShotCastReady=false;
    private bool PowerShotCasting=false;

    void Start()
    {
        PowerShotCd = PowerShotStartCd;
        PowerShotChargeTimer = PowerShotStartChargeTimer;
    }
    void Update()
    {
        //Only castable on ground.
        if(Input.GetKey(KeyCode.C) && cont.m_Grounded && PowerShotChargeReady)
        {
            PowerShotCharging = true;
            PowerShotCasting  = false;

            PowerShotChargeTimer -= Time.deltaTime;

            if(PowerShotChargeTimer <= 0)
            {
                PowerShotCastReady = true;
            }
            else
            {
                PowerShotCastReady = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.C) && cont.m_Grounded)
        {
            if(PowerShotCastReady && !mov.isMoving && !mov.jump )
            {
                PowerShotCasting = true;
               
            }
            else
            {
                PowerShotCasting = false;
            }

            PowerShotChargeTimer = PowerShotStartChargeTimer;
            PowerShotCharging = false;

        }

        anim.SetBool("PowerShortCastReady",PowerShotCastReady);
        anim.SetBool("PowerShotCasting",PowerShotCasting);
        anim.SetBool("PowerShotCharging",PowerShotCharging);
        




    }
    
    
}