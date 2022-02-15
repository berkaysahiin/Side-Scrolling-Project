using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public static cameraShake Instance {get; private set; }
    private CinemachineVirtualCamera _cinemachineVirtualCamera; 
    private float shakeTimer;

    private void Awake() {
        Instance = this;
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensitiy, float time)
    {
        CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin =
        _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensitiy;
        shakeTimer = time;
    }

    private void Update() {
        if(shakeTimer > 0 )
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                //Timer over!
                CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin =
                _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
