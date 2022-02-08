using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShooter : MonoBehaviour
{
    private Animator _anim;
    public bool isShooting; 
    private playerAttackManager _pam;
    
   
    void Start()
    {
        _pam = this.GetComponent<playerAttackManager>();
        _anim = this.GetComponent<Animator>();
    }

    
    void Update()
    {
        
        if(Input.GetKey(KeyCode.X) && _pam._gunSwapper.gunEnable)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
        
        _anim.SetBool("isShooting",isShooting);
        
    }
}
