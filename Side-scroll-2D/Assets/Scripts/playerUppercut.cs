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
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange;
    
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

           Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);

           foreach(Collider2D enemy in hitEnemies)
           {
               Debug.Log("1 we hit" + enemy.name);
           }
        }
        _anim.SetBool("uppercut",uppercut);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
