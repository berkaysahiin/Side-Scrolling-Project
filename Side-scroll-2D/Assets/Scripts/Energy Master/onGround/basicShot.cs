using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicShot : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direction;
    private float speed = 15;
    private CharacterController2D _char;
    void Start()
    {
        _char = GameObject.Find("player").GetComponent<CharacterController2D>(); 

        if(_char.m_FacingRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed * direction;

         transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y, transform.localScale.z);
        
        

        Destroy(gameObject , 2f);

    }

    private void OnTriggerEnter2D(Collider2D other)
{
    Destroy(this.gameObject);
    
     if(other.gameObject.layer == 6 )
    {
        Debug.Log("damage done");
    }
    
}
    
}
