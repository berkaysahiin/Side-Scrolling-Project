using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPowerShot : MonoBehaviour
{
    private playerAttackManager _pam;
    public bool powerShot;
    public GameObject _powershot;
    private float cooldown;
    public float startCooldown;
    public float waitSeconds;
    void Start()
    {
        _pam = GetComponent<playerAttackManager>();   
        cooldown = startCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.W) && _pam.isEnableGround && cooldown <= 0)
        {
            cooldown = startCooldown;
            powerShot = true;
            StartCoroutine(PowerShot());
        }
        

        _pam._anim.SetBool("powerShot",powerShot);


        
    }

    IEnumerator PowerShot()
    {
        yield return new WaitForSecondsRealtime(waitSeconds);
        Instantiate(_powershot, _pam.transform2.position , _pam.transform2.rotation );
        Debug.Log("power shot");
        powerShot = false;
        
        
    }
    
}
