using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
   CinemachineVirtualCamera vcam;
   
   public CinemachineVirtualCamera Vcam => vcam ??= GetComponent<CinemachineVirtualCamera>();

   private void OnEnable()
   {
     EventManager.OnPlayerSizeChanged.AddListener(ChangeSize);
   }

   private void OnDisable()
   {
      EventManager.OnPlayerSizeChanged.RemoveListener(ChangeSize);
   }
   

   private void ChangeSize()
   {
      Vcam.m_Lens.OrthographicSize = 15f;
   }
}
