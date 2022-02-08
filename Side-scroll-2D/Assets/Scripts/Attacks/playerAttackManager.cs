using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackManager : MonoBehaviour
{
    public float globalCooldown=0f;
    public float startGlobalCooldown;
    public Animator _anim;
    public CharacterController2D _char;
    public Transform transform1;
    public Transform transform2;
    public Transform transform3;
    public Transform transform4;
    public LayerMask enemyLayers;
    public float attackRadius;
    public float attackRadius2;
    public playerFlyingKick _flying;
    public bool isEnableGround;
    public bool isEnableAir;
    public gunSwapper _gunSwapper;

    void Update()
    {
        globalCooldown -= Time.deltaTime; 

        if(_char.m_Grounded && globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable)
        {
            isEnableGround = true;
        }
        else
        {
            isEnableGround = false;
        }

        if(!_char.m_Grounded && globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable)
        {
            isEnableAir = true;
        }
        else
        {
            isEnableAir = false;
        }



    }

    
}
