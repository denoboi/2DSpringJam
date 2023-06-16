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
    
    
    
    AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Attack();
    }

    void Attack()
    {
        AgentAnimation.Animator.SetTrigger("Attack");
        
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            EnemyKnockBack enemyKnockBack = enemy.GetComponent<EnemyKnockBack>();
            SkeletonHealth skeletonHealth = enemy.GetComponent<SkeletonHealth>();
            
            
            
            if (enemyHealth != null || skeletonHealth != null)
            {
                enemyHealth.TakeDamage(DamageValue);
                enemyKnockBack.PlayKnockBack(gameObject);
                skeletonHealth.TakeDamage(DamageValue);
                
                CameraShake.Instance.ShakeCamera(3,.1f);
                Debug.Log("Enemy took damage.");
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


