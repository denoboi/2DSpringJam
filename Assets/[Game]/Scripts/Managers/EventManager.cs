using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
   public static UnityEvent OnPlayerDead = new UnityEvent();
   public static UnityEvent OnPlayerSizeChanged = new UnityEvent();

}
