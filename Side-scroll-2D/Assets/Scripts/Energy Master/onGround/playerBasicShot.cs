using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBasicShot : MonoBehaviour
{
   private playerAttackManager _pam;
   public bool basicShot;
   public GameObject _basicShotPrefab;
   public float sharedCooldown;
   public float startSharedCooldown;
   [SerializeField]private float waitSeconds;

   void Start()
   {
       _pam = GetComponent<playerAttackManager>();
       sharedCooldown = startSharedCooldown;
       
   }

   void Update()
   {
       sharedCooldown -= Time.deltaTime;

       if(Input.GetKeyDown(KeyCode.E) && _pam.isEnableGround && sharedCooldown <= 0)
       {
           sharedCooldown = startSharedCooldown;
           basicShot = true;
           StartCoroutine(BasicShot());
       }

    _pam._anim.SetBool("basicShot",basicShot);
   }

   IEnumerator BasicShot()
   {
       yield return new WaitForSecondsRealtime(waitSeconds);
       Instantiate(_basicShotPrefab, _pam.transform1.position,_pam.transform1.rotation);
       basicShot = false;
   }

}
