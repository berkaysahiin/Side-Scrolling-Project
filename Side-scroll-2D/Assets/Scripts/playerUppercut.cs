using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUppercut : MonoBehaviour
{
    private bool uppercut;
    public CharacterController2D _cont;
    public Animator _anim;
    private float cooldown;
    public float startCooldown;
    public playerActionManager _pam;
    
    void Start()
    {
        cooldown = startCooldown;
    }

   
    void Update()
    {
        uppercut = false;
        cooldown -= Time.deltaTime;


        if(Input.GetKeyDown(KeyCode.X) && _cont.m_Grounded && cooldown <= 0 && _pam.globalCooldown <= 0 )
        {
            uppercut = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;
            
        }
        _anim.SetBool("uppercut",uppercut);

        
    }
}