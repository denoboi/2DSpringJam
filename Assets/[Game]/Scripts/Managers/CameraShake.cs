using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private CinemachineVirtualCamera _virtualCamera;

    public CinemachineVirtualCamera VirtualCamera => _virtualCamera ??= GetComponent<CinemachineVirtualCamera>();

    private void Awake()
    {
        Instance = this;
       
    }
    
    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cmbmp =
            VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmbmp.m_AmplitudeGain = intensity;
        StartCoroutine(StopShake(time, cmbmp));
    }
    
    private IEnumerator StopShake(float time, CinemachineBasicMultiChannelPerlin cmbmp)
    {
        yield return new WaitForSeconds(time);
        cmbmp.m_AmplitudeGain = 0;
    }
}
