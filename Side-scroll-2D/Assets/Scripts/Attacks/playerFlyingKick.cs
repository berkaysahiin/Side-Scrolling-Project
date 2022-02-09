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
    public BoxCollider2D _collider;
    private bool collide;

    void Start()
    {
        cooldown = startCooldown;
        
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.V) && _pam.isEnableGround )
        {
            isFlying = true;
            cooldown = startCooldown;
            
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
            if(!collide)
            {
                player.position = new Vector3(player.position.x + move*player.localScale.x*Time.deltaTime , player.position.y ,player.position.z);
                Debug.Log("irmaga gideyrum");    
                yield return null;
            }
            else
            {
                break;
            }
        }
        isFlying = false;
        collide = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
        {       
            if(isFlying){
            Debug.Log("collision");
            collide = true;
            }
            
        }
    


  // end of class        
}
