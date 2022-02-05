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
    public Transform longPoint1;
    public Transform longPoint2;
    public LayerMask enemyLayers;
    public float pointRadius;
    
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

             Collider2D[] hitEnemies1 = Physics2D.OverlapCircleAll(longPoint1.position, pointRadius,enemyLayers);
             Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(longPoint2.position, pointRadius,enemyLayers);

           foreach(Collider2D enemy in hitEnemies1)
           {
               Debug.Log("2 we hit" + enemy.name);
           }

           foreach(Collider2D enemy in hitEnemies2)
           {
               Debug.Log("3 we hit" + enemy.name);
           }
            
            
        }
        anim.SetBool("twoside",twoside);
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(longPoint1.position, pointRadius);
        Gizmos.DrawWireSphere(longPoint2.position, pointRadius);


    }
}
