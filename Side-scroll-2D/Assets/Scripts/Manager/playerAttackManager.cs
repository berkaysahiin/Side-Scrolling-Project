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
    public bool isEnableAirGround;
    public gunSwapper _gunSwapper;
    private energyObserver _energyObserver;
    public float direction;

    private void Start() {
        _energyObserver = GetComponent<energyObserver>();
    }

    void Update()
    {
        globalCooldown -= Time.deltaTime; 

        if(_char.m_Grounded && globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable && !_energyObserver.onGroundSpell)
        {
            isEnableGround = true;
        }
        else
        {
            isEnableGround = false;
        }

        if(!_char.m_Grounded && globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable
         && !_energyObserver.inAirSpell)
        {
            isEnableAir = true;
        }
        else
        {
            isEnableAir = false;
        }

        if(globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable && !_energyObserver.onGroundSpell && 
        !_energyObserver.inAirSpell)
        {
            isEnableAirGround = true;
        }
        else
        {
            isEnableAir = false;
        }




        if(_char.m_FacingRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }



    }

    
}
