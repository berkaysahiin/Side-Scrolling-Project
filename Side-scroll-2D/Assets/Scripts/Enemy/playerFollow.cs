using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private float radius;
    [SerializeField] private enemyPatrol _enemyPatrol;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(playerCheck.position, radius , playerLayer);

        foreach(Collider2D player in hitPlayer)
        {
            if(player.gameObject.transform.position.x > this.gameObject.transform.position.x)
            {
                if(this.gameObject.transform.localScale.x  < 0)
                {
                    _enemyPatrol.Flip();
                }
                else
                {
                    
                }
            }
            else if(player.gameObject.transform.position.x < this.gameObject.transform.position.x)
            {
                 if(this.gameObject.transform.localScale.x  > 0)
                {
                    _enemyPatrol.Flip();
                }
                else
                {
                    
                }
            }
        }
    }

     private void OnDrawGizmosSelected() 
    {
       Gizmos.DrawWireSphere(playerCheck.position, radius);
    }
}
