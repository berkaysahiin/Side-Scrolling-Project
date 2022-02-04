using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUppercut : MonoBehaviour
{
    private bool uppercut;
    public CharacterController2D _cont;
    public Animator _anim;
    void Start()
    {
        
    }

   
    void Update()
    {
        uppercut =false;

        if(Input.GetKeyDown(KeyCode.X) && _cont.m_Grounded)
        {
            uppercut = true;
        }
        _anim.SetBool("uppercut",uppercut);
        
        
    }
}
