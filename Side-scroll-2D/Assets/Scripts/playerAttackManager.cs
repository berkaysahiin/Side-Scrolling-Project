using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackManager : MonoBehaviour
{
    public float globalCooldown=0f;
    public float startGlobalCooldown;
    public Animator _anim;
    public CharacterController2D _char;
    public Transform transform1;
    public Transform transform2;
    public Transform transform3;
    public Transform transform4;
    public LayerMask enemyLayers;
    public float attackRadius;
    public float attackRadius2;


    void Update()
    {
        globalCooldown -= Time.deltaTime;   
    }

    
}
