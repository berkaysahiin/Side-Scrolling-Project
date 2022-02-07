using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlyingKick : MonoBehaviour
{
    public bool isFlying=false;
    private float cooldown;
    public float startCooldown;
    public playerAttackManager _pam;
    private float duration;
    public float startDuration;
    public Transform player;
    public float move;

    void Start()
    {
        cooldown = startCooldown;
        
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.V) && _pam._char.m_Grounded && _pam.globalCooldown <= 0 && cooldown <= 0 && !isFlying )
        {
            isFlying = true;
            cooldown = startCooldown;
            _pam.globalCooldown = _pam.startGlobalCooldown;

            StartCoroutine(FlyingKick());
        }

        
        Debug.Log(isFlying);


    _pam._anim.SetBool("isFlying",isFlying);
       // update ends
    }

    IEnumerator FlyingKick()
    {

        for(duration = startDuration ; duration >= 0 ; duration -= Time.deltaTime)
        {
            player.position = new Vector3(player.position.x + move*player.localScale.x , player.position.y ,player.position.z);
            Debug.Log("irmaga gideyrum");    
            yield return null;
            
        }
        isFlying = false;

    }

}
