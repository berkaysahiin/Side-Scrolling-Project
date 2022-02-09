using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShooter : MonoBehaviour
{
    private Animator _anim;
    public bool isShooting; 
    private playerAttackManager _pam;
    public GameObject bulletPrefab;
    private GameObject clone;
    
   
    void Start()
    {
        _pam = this.GetComponent<playerAttackManager>();
        _anim = this.GetComponent<Animator>();
    }

    
    void Update()
    {
        
        if(Input.GetKey(KeyCode.X) && _pam._gunSwapper.gunEnable && _pam.globalCooldown <= 0 )
        {
            isShooting = true;
            
        }
        else
        {
            isShooting = false;
        }
        
        _anim.SetBool("isShooting",isShooting);
        
    }
    
    void FixedUpdate()
    {
        if(isShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    
    IEnumerator Shoot()
    {
        clone = Instantiate(bulletPrefab, _pam.transform2.position , _pam.transform2.rotation );

        
        yield return null;

    }

    
}
