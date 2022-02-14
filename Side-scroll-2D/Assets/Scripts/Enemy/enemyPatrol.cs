using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [HideInInspector] public bool mustPatrol;
    private bool mustFlipGround;
    [SerializeField ]private float radius;
    [SerializeField ]private LayerMask groundLayer;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb2d;
    [SerializeField] private Transform groundCheck;
    [SerializeField]private BoxCollider2D boxCollider;
    private void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
        mustPatrol = true;
    }
    private void Update() 
    {
        if(mustPatrol)
        {
            Patrol();
        }   
    }

    private void FixedUpdate() 
    {
        if(mustPatrol)
        {
            mustFlipGround = !Physics2D.OverlapCircle(groundCheck.position,radius,groundLayer);
            
        }
        
    }

    void Patrol()
    {
        rb2d.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime,rb2d.velocity.y);

        if(mustFlipGround || boxCollider.IsTouchingLayers(groundLayer) )
        {
            Flip();
        }
    }
    void Flip()
    {   
        mustPatrol = false;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
        mustPatrol = true;
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        
    }

}

