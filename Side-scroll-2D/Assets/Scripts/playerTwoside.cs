using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoside : MonoBehaviour
{
    private bool twoside;
    public CharacterController2D _contr;
    public Animator anim;
    private float cooldown;
    public float startCooldown;
    public playerActionManager _pam;
    
    void Start()
    {
        cooldown = startCooldown;
    }

    
    void Update()
    {
        twoside = false;
        cooldown -= Time.deltaTime;
       

        if(Input.GetKeyDown(KeyCode.C) && _contr.m_Grounded && cooldown <= 0  && _pam.globalCooldown <= 0  )
        {
            twoside = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;
            
        }
        anim.SetBool("twoside",twoside);
    }
}
