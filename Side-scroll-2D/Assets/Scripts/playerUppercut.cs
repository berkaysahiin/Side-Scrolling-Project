using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUppercut : MonoBehaviour
{
    private bool uppercut;
    private float cooldown;
    public float startCooldown;
    public playerAttackManager _pam;
    
    void Start()
    {
        cooldown = startCooldown;
    }
    void Update()
    {
        uppercut = false;
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.X) && _pam._char.m_Grounded && cooldown <= 0 && _pam.globalCooldown <= 0 )
        {
            uppercut = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;

           Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_pam.transform1.position, _pam.attackRadius ,_pam.enemyLayers);

           foreach(Collider2D enemy in hitEnemies)
           {
               Debug.Log("1 we hit" + enemy.name);
           }
        }
        _pam._anim.SetBool("uppercut",uppercut);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_pam.transform1.position,_pam.attackRadius);
    }
}
