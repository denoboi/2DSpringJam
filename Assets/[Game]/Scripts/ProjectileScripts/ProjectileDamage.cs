using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private int _projectileDamage = 20;

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyHealth enemy = other.gameObject.GetComponentInChildren<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(_projectileDamage);
            Destroy(gameObject);
        }
        
        PatrollingEnemyHealth patrollingEnemyEnemy = other.gameObject.GetComponentInChildren<PatrollingEnemyHealth>();

        if (patrollingEnemyEnemy != null)
        {
            patrollingEnemyEnemy.TakeDamage(_projectileDamage);
            Destroy(gameObject);
        }
    }
    
   
}
