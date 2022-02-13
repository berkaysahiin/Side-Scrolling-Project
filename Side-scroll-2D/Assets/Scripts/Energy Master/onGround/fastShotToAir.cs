using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastShotToAir : MonoBehaviour
{
    private playerAttackManager _pam; 
    [SerializeField]private float waitSeconds;
    public bool isFastShotToAir;
    private Quaternion _qua;
    [SerializeField]private GameObject _fastShotToAir;
    [SerializeField]private playerBasicShot _playerBasicShot;
    [SerializeField]private Transform transformFastShotToAir;
    void Start()
    {
        _pam = GetComponent<playerAttackManager>();
    }

    
    void Update()
    {
        if(_pam._char.m_FacingRight)
        {
            _qua = Quaternion.Euler(0,0,35);
        }
        else
        {
            _qua = Quaternion.Euler(0,0,-35);
        }

        if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && _pam.isEnableGround  && _playerBasicShot.sharedCooldown <= 0)
        {
            isFastShotToAir = true;
            StartCoroutine(FastShotToAir());
            _playerBasicShot.sharedCooldown = _playerBasicShot.startSharedCooldown;
        }

        _pam._anim.SetBool("isFastShotToAir",isFastShotToAir);
    }

    IEnumerator FastShotToAir()
    {
        
        yield return new WaitForSecondsRealtime(waitSeconds);
        Instantiate(_fastShotToAir, transformFastShotToAir.position, _qua);
        isFastShotToAir = false;
    }
}
