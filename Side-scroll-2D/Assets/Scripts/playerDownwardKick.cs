using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDownwardKick : MonoBehaviour
{
    private bool downkick;
    private float cooldown;
    public float startCooldown;
    public playerAttackManager _pam;

    void Start()
    {
        cooldown = startCooldown;
        
    }
    void Update()
    {
        downkick = false;
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.X) && !_pam._char.m_Grounded && _pam.globalCooldown <= 0 &&  cooldown <= 0 )
        {
            downkick = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;

            Debug.Log("attack 4");

           Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_pam.transform4.position, _pam.attackRadius ,_pam.enemyLayers);

           foreach(Collider2D enemy in hitEnemies)
           {
               Debug.Log("4 we hit" + enemy.name);
           }
        }
    _pam._anim.SetBool("downkick",downkick);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_pam.transform4.position,_pam.attackRadius);
    }

    
}
