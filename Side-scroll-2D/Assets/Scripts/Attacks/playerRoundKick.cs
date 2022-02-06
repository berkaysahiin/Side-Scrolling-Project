using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRoundKick : MonoBehaviour
{
    private float cooldown;
    public float startCooldown;
    private bool roundkick;
    public playerAttackManager _pam;
    
   void Start()
    {
        cooldown = startCooldown;
        
    }
    void Update()
    {
        roundkick = false;
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R) && _pam._char.m_Grounded && _pam.globalCooldown <= 0 &&  cooldown <= 0 )
        {
            roundkick = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;

            Debug.Log("attack Roundkick");

            Collider2D[] hitEnemies1 = Physics2D.OverlapCircleAll(_pam.transform2.position, _pam.attackRadius2,_pam.enemyLayers);

           foreach(Collider2D enemy in hitEnemies1)
           {
               Debug.Log("Round kick hit" + enemy.name);
           }
           
        }
    _pam._anim.SetBool("roundkick",roundkick);
    }
}
