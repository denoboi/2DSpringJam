using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCloseAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayer;

    [field:SerializeField] public int DamageValue { get; set; }
    
    private AgentAnimation _agentAnimation;
    private PlayerHealth _agentHealth;
    
    
    AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();
    public PlayerHealth PlayerHealth => _agentHealth ??= GetComponent<PlayerHealth>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Attack();
    }

    void Attack()
    {
        if(PlayerHealth.IsPlayerDead) return;
        
        AgentAnimation.Animator.SetTrigger("Attack");
        
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            EnemyKnockBack enemyKnockBack = enemy.GetComponent<EnemyKnockBack>();
            PatrollingEnemyHealth patrollingEnemyHealth = enemy.GetComponentInChildren<PatrollingEnemyHealth>();
            
            
            
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(DamageValue);
                enemyKnockBack.PlayKnockBack(gameObject);
                
                
                CameraShake.Instance.ShakeCamera(3,.1f);
                Debug.Log("Enemy took damage.");
            }
            else if(patrollingEnemyHealth != null)
            {
                patrollingEnemyHealth.TakeDamage(DamageValue);
                //enemyKnockBack.PlayKnockBack(gameObject);
                CameraShake.Instance.ShakeCamera(3,.1f);
                Debug.Log("Skeleton took damage.");
            }
            else
            {
                continue;
                Debug.Log("EnemyHealth is null");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (_attackPoint == null) return;
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
    
    
}


