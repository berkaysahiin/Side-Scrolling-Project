using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBasicShot : MonoBehaviour
{
   private playerAttackManager _pam;
   public bool basicShot;
   public GameObject _basicShotPrefab;
   private float cooldown;
   public float startCooldown;
   [SerializeField]private float waitSeconds;

   void Start()
   {
       _pam = GetComponent<playerAttackManager>();
       cooldown = startCooldown;
       
   }

   void Update()
   {
       cooldown -= Time.deltaTime;

       if(Input.GetKeyDown(KeyCode.E) && _pam.isEnableGround && cooldown <= 0)
       {
           cooldown = startCooldown;
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
