using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActionManager : MonoBehaviour
{
    public float globalCooldown=0f;
    public float startGlobalCooldown;

    void Update()
    {
        globalCooldown -= Time.deltaTime;   
    }

    
}
