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
    public playerPowerShot _playerPowerShot;
    public playerBasicShot _playerBasicShot;
    public playerNormalShot _playerNormalShot;
    public normalShotToFront _normalShotToFront;
    public normalShotToDown _normalShotToDown;
    public fastShotToAir _fastShotToAir;
    public RealNormalShotToAir _normalShotToAir;

    void Update()
    {
        globalCooldown -= Time.deltaTime; 

        if(_char.m_Grounded && globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable && !_playerPowerShot.powerShot
            && !_playerBasicShot.basicShot && !_fastShotToAir.isFastShotToAir && !_normalShotToAir.isNormalShotToAir)
        {
            isEnableGround = true;
        }
        else
        {
            isEnableGround = false;
        }

        if(!_char.m_Grounded && globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable
         && !_playerPowerShot.powerShot  && !_playerBasicShot.basicShot && !_normalShotToFront.isNormalShotToFront && !_normalShotToDown.isNormalShotToDown)
        {
            isEnableAir = true;
        }
        else
        {
            isEnableAir = false;
        }

        if(globalCooldown <= 0 && !_flying.isFlying && !_gunSwapper.gunEnable && !_playerPowerShot.powerShot)
        {
            isEnableAirGround = true;
        }
        else
        {
            isEnableAir = false;
        }

        



    }

    
}
