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
    
    void Start()
    {
        _pam = GetComponent<playerAttackManager>();
        _anim = GetComponent<Animator>(); 
        gunEnable = false;  
        cooldown = startCooldown;
    }

    void Update()
    {
        gunOff = false;
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Q) && !gunEnable && cooldown <= 0  )
        {
            gunEnable = true;
            cooldown = startCooldown;
        }
        
        else if(Input.GetKeyDown(KeyCode.Q) && gunEnable && cooldown <= 0 )
        {
            gunEnable = false;
            gunOff = true;
            cooldown = startCooldown;
        }
        
     _anim.SetBool("gunEnable",gunEnable);
        
    }
}
