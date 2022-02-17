using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Perspective : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private Transform _player;
    
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
             _cinemachineVirtualCamera.m_Lens.OrthographicSize += 0.3f;
             _player.localScale = new Vector3(_player.localScale.x *(_cinemachineVirtualCamera.m_Lens.OrthographicSize/_cinemachineVirtualCamera.m_Lens.OrthographicSize +0.07f) , 
             _player.localScale.y * (_cinemachineVirtualCamera.m_Lens.OrthographicSize/_cinemachineVirtualCamera.m_Lens.OrthographicSize +0.07f),
              _player.localScale.z);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
             _cinemachineVirtualCamera.m_Lens.OrthographicSize -= 0.3f;
             _player.localScale = new Vector3(_player.localScale.x* (_cinemachineVirtualCamera.m_Lens.OrthographicSize/_cinemachineVirtualCamera.m_Lens.OrthographicSize -0.05f) , _player.localScale.y * (_cinemachineVirtualCamera.m_Lens.OrthographicSize/_cinemachineVirtualCamera.m_Lens.OrthographicSize -0.05f) , _player.localScale.z);

        }

        
    }


    IEnumerator ZoomIn()
    {
        yield return null;
    }
}
