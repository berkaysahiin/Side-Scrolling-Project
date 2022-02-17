using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grippleHook : MonoBehaviour
{
    [SerializeField] private TargetJoint2D _targetJoint;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float cooldown;
                     public float startCooldown;
    void Start()
    {
        _targetJoint.enabled = true;
        
    }

    
    void Update()
    {
        cooldown -= Time.deltaTime;

        _targetJoint.anchor = new Vector2(transform.position.x, transform.position.y);
        _targetJoint.target = new Vector2(targetTransform.position.x , targetTransform.position.y );

        if(Input.GetKeyDown(KeyCode.LeftShift) && cooldown <= 0)
        {
            _targetJoint.maxForce = 10000f;
            cooldown = startCooldown;
        }
        else
        {
            _targetJoint.maxForce = 0;
        }
        
    }
}
