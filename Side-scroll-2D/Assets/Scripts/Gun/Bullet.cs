using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D _rigidbody2d;
    private bool hit = false;
    private Animator _anim;
    private CharacterController2D _char;
    private float direction;

    void Awake()
    {

    }
    
    void Start()
    {
        this.gameObject.layer =  7;

        _char = GameObject.Find("player").GetComponent<CharacterController2D>();
        if(_char.m_FacingRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        hit = false;
        _anim = this.GetComponent<Animator>();
        
        _rigidbody2d.velocity = transform.right * speed * direction;

        Destroy(gameObject , 1f );
    }

    void Update()
    {
       _anim.SetBool("hit", hit);
      
    }

/*
private void OnCollisionEnter2D(Collision2D other)
{
    Destroy(this.gameObject);
}
*/
private void OnTriggerEnter2D(Collider2D other)
{
    Destroy(this.gameObject);
    hit = true;
    if(other.gameObject.layer == 6 )
    {
        Debug.Log("damage done");
    }
}



}
