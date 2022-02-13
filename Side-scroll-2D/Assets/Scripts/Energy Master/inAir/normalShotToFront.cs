using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShotToFront : MonoBehaviour
{
    private playerAttackManager _pam; 
    [SerializeField]private float waitSeconds;
    public bool isNormalShotToFront;
    [SerializeField]private GameObject _normalShotToFront;
    [SerializeField]private playerBasicShot _playerBasicShot;

   
    void Start()
    {
        _pam = GetComponent<playerAttackManager>();        
    }

    
    void Update()
    {
          
        if(Input.GetKeyDown(KeyCode.E) && _pam.isEnableAir && _playerBasicShot.sharedCooldown <= 0 &&  !Input.GetKey(KeyCode.DownArrow))
        {
            isNormalShotToFront = true;
            StartCoroutine(NormalShotToFront());
            _playerBasicShot.sharedCooldown = _playerBasicShot.startSharedCooldown;
        }

        _pam._anim.SetBool("isNormalShotToFront",isNormalShotToFront);
    }

    IEnumerator NormalShotToFront()
    {
        yield return new WaitForSecondsRealtime(waitSeconds);
        Instantiate(_normalShotToFront,  _pam.transform2.position , _pam.transform2.rotation );
        isNormalShotToFront = false;
    }
}
