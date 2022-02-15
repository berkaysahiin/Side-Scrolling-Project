using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyObserver : MonoBehaviour
{
                                                         // on ground spells
    public playerPowerShot _playerPowerShot;
    public playerNormalShot _playerNormalShot;
    public RealNormalShotToAir _playerNormalShotToAir;
    public playerBasicShot _playerBasicShot;
    public fastShotToAir _playerBasicShotToAir;

                                                        // in air spells
    public normalShotToDown _playerBasicShotToDown;
    public normalShotToFront _playerBasicShotToFront;
                                                        // To check if a spell is casting
    public bool onGroundSpell;
    public bool inAirSpell;


    private void Start() 
    {
        _playerPowerShot = GetComponent<playerPowerShot>();
        _playerNormalShot = GetComponent<playerNormalShot>();
        _playerNormalShotToAir = GetComponent<RealNormalShotToAir>();
        _playerBasicShot =  GetComponent<playerBasicShot>();
        _playerBasicShotToAir =  GetComponent<fastShotToAir>();

        _playerBasicShotToDown = GetComponent<normalShotToDown>();
        _playerBasicShotToFront =  GetComponent<normalShotToFront>();

    }

    private void Update() {
        
         if(!_playerPowerShot.powerShot && !_playerNormalShot.normalShot && !_playerNormalShotToAir.isNormalShotToAir &&
            !_playerBasicShot.basicShot && !_playerBasicShotToAir.isFastShotToAir)
        {
            onGroundSpell = false;
        }
        else
        {
            onGroundSpell = true;
        }

        if( !_playerBasicShotToFront.isNormalShotToFront && !_playerBasicShotToDown.isNormalShotToDown)
        {
            inAirSpell = false;
        }
        else
        {
            inAirSpell = true;
        }
    }


}

    



    
