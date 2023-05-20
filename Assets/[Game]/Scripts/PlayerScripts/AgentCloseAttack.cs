using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCloseAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayer;
    
    
    [SerializeField] private PlayerData _playerData;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Attack();
    }

    void Attack()
    {
        //TODO Play attack animation
        
        
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_playerData.Damage);
                Debug.Log("Enemy took damage.");
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (_attackPoint == null) return;
        
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    
}


