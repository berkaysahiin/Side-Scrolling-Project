using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShooter : MonoBehaviour
{
    private Animator _anim;
    public bool isShooting; 
    private playerAttackManager _pam;
    [SerializeField] private Transform _gunSpawm;
    public GameObject bulletPrefab;
    private GameObject clone;
    [SerializeField] private ParticleSystem _particle; 

    private void Awake() 
    {
        
    }
    
   
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
            _particle.Play();
            
        }
        else
        {
            isShooting = false;
            _particle.Stop();
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
        clone = Instantiate(bulletPrefab, _gunSpawm.position , _gunSpawm.rotation );

        
        yield return null;

    }

    
}
