using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwapper : MonoBehaviour
{
    private Animator _anim;
    public bool gunEnable;
    private playerAttackManager _pam;
    public bool gunOff;
    private float cooldown;
    public float startCooldown;
    private gunShooter _gunShooter;

    
    void Start()
    {
        _pam = GetComponent<playerAttackManager>();
        _anim = GetComponent<Animator>(); 
        gunEnable = false;  
        cooldown = startCooldown;
        _gunShooter = this.GetComponent<gunShooter>();
    }

    void Update()
    {
        gunOff = false;
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Q) && !gunEnable &&  _pam.globalCooldown <= 0 && cooldown <= 0 && !_pam._flying.isFlying && !_pam._playerPowerShot.powerShot && !_pam._playerBasicShot.basicShot)
        {
            gunEnable = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown ;
            Debug.Log(_pam.globalCooldown);
        }
        
        else if(Input.GetKeyDown(KeyCode.Q) && gunEnable && !_gunShooter.isShooting && cooldown <= 0 )
        {
            gunEnable = false;
            gunOff = true;
            cooldown = startCooldown;
            Debug.Log(_pam.globalCooldown);


        }
        
     _anim.SetBool("gunEnable",gunEnable);
        
    }
}
