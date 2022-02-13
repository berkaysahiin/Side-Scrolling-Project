using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShotToDown : MonoBehaviour
{
   private playerAttackManager _pam;
  [SerializeField]private float waitSeconds;
  public bool isNormalShotToDown;
  [SerializeField]private GameObject _normalShotToDown;
  [SerializeField]private playerBasicShot _playerBasicShot;
  [SerializeField]private Transform _transform;

  private void Start() {
      _pam = GetComponent<playerAttackManager>();
  }
  private void Update() {
      if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.DownArrow) && _pam.isEnableAir && _playerBasicShot.sharedCooldown <= 0)
      {
          isNormalShotToDown = true;
          StartCoroutine(NormalShotToDown());
          _playerBasicShot.sharedCooldown = _playerBasicShot.startSharedCooldown;
          Debug.Log("split to down");
      }

      _pam._anim.SetBool("isNormalShotToDown",isNormalShotToDown);
  }

  IEnumerator NormalShotToDown()
  {
      yield return new WaitForSecondsRealtime(waitSeconds);
      Instantiate(_normalShotToDown ,  _transform.position , _transform.rotation );
      isNormalShotToDown = false;
  }
  
}