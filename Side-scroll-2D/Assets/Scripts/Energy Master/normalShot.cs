using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShot : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direction;
    private float speed = 12.5f;
    private CharacterController2D _char;
    // Start is called before the first frame update
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

        Destroy(gameObject , 3f );

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
