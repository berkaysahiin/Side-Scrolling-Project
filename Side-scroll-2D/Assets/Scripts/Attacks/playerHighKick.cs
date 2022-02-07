using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHighKick : MonoBehaviour
{
    private bool highkick;
    private float cooldown;
    public float startCooldown;
    public playerAttackManager _pam;
    void Start()
    {
        cooldown = startCooldown;
        
    }

    // Update is called once per frame
    void Update()
    {
        highkick = false;
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.C) &&_pam.isEnableAir &&  cooldown <= 0 )
        {
            highkick = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;

            Debug.Log("attack 5");

           Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_pam.transform4.position, _pam.attackRadius+1 ,_pam.enemyLayers);

           foreach(Collider2D enemy in hitEnemies)
           {
               Debug.Log("5 we hit" + enemy.name);
           }
        }
    _pam._anim.SetBool("highkick",highkick);
        
    }
}
