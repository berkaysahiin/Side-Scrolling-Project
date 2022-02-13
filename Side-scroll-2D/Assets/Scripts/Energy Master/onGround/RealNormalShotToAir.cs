using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealNormalShotToAir : MonoBehaviour
{
    private playerAttackManager _pam; 
    [SerializeField]private float waitSeconds;
    private float direction;
    public bool isNormalShotToAir;
    private Quaternion _qua;
    [SerializeField]private GameObject _NormalShotToAir;
    [SerializeField]private playerNormalShot _playerNormalShot;
    [SerializeField]private Transform transformNormalShotToAir;

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

        if(Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.UpArrow) && _pam.isEnableGround  && _playerNormalShot.cooldown <= 0)
        {
            isNormalShotToAir = true;
            StartCoroutine(NormalShotToAir());
            _playerNormalShot.cooldown = _playerNormalShot.startCooldown;
        }

        _pam._anim.SetBool("isNormalShotToAir",isNormalShotToAir);
    }

    IEnumerator NormalShotToAir()
    {
        
        yield return new WaitForSecondsRealtime(waitSeconds);
        Instantiate(_NormalShotToAir, transformNormalShotToAir.position, _qua);
        isNormalShotToAir = false;
    }
}
