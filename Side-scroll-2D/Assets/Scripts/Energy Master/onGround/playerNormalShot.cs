using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNormalShot : MonoBehaviour
{
    private playerAttackManager _pam;
    public bool normalShot;
    public GameObject _normalShot;
    public float cooldown;
    [SerializeField]public float startCooldown;
    [SerializeField]private float waitSeconds;
    private void Start() 
    {
        _pam = GetComponent<playerAttackManager>();
        cooldown = startCooldown;    
    }

    private void Update() 
    {
        cooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.S) && _pam.isEnableGround && cooldown <= 0)
        {
            cooldown = startCooldown;
            normalShot = true;
            StartCoroutine(NormalShot());
        }
        _pam._anim.SetBool("normalShot", normalShot);
    }

    IEnumerator NormalShot()
    {
        yield return new WaitForSecondsRealtime(waitSeconds);
        Instantiate(_normalShot,  _pam.transform2.position , _pam.transform2.rotation );
        normalShot = false;
    }
}

    
