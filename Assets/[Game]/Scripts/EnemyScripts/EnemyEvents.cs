using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEvents : MonoBehaviour
{
    public event Action OnEnemyAttack, OnEnemyMove, OnEnemyDead;
    
    public void EnemyAttack()
    {
        OnEnemyAttack?.Invoke();
    }
    
    public void EnemyMove()
    {
        OnEnemyMove?.Invoke();
    }

}
