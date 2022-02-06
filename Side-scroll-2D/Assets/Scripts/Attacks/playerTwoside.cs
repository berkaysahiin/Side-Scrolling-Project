using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoside : MonoBehaviour
{
    private bool twoside;
    private float cooldown;
    public float startCooldown;
    public playerAttackManager _pam;
    
    void Start()
    {
        cooldown = startCooldown;
    }
    
    void Update()
    {
        twoside = false;
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.C) && _pam._char.m_Grounded && cooldown <= 0  && _pam.globalCooldown <= 0  )
        {
            twoside = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;

             Collider2D[] hitEnemies1 = Physics2D.OverlapCircleAll(_pam.transform2.position, _pam.attackRadius2,_pam.enemyLayers);
             Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(_pam.transform3.position, _pam.attackRadius2,_pam.enemyLayers);

           foreach(Collider2D enemy in hitEnemies1)
           {
               Debug.Log("2 we hit" + enemy.name);
           }

           foreach(Collider2D enemy in hitEnemies2)
           {
               Debug.Log("3 we hit" + enemy.name);
           }
            
            
        }
        _pam._anim.SetBool("twoside",twoside);
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_pam.transform2.position, _pam.attackRadius2);
        Gizmos.DrawWireSphere(_pam.transform3.position, _pam.attackRadius2);


    }
}
