using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _attackRate = 1f;
    [SerializeField] private float _attackRange = 3f;
    
    private GameObject _player;
    private EnemyAgent _enemyAgent;
    private bool _isAttacking;
    
    public EnemyAgent EnemyAgent => _enemyAgent ??= GetComponent<EnemyAgent>();

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (_isAttacking)
            return;

        
        // Check if the enemy is within attacking range of the player
        CheckDistance();
    }

    void CheckDistance()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        if (distanceToPlayer <= _attackRange)
        {
            Attack();
        }
        else if (distanceToPlayer > _attackRange)
        {
            EnemyAgent.StartMoving();
        }
    }

    void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        _isAttacking = true;

        // Play attack animation
        // Use your own animation system or Unity's Animator
        // Example: GetComponent<Animator>().SetTrigger("Attack");

        // Wait for the attack delay
        yield return new WaitForSeconds(_attackRate);

        // Check if the player is still within attacking range
        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        if (distanceToPlayer <= _attackRange)
        {
           
            // Apply damage to the player or trigger any other desired effects
            _player.GetComponentInChildren<PlayerHealth>().TakeDamage(_damage);
            EnemyAgent.StopMoving();
        }
        

        // Stop attack animation
        // Example: GetComponent<Animator>().ResetTrigger("Attack");

        _isAttacking = false;
        EnemyAgent.FollowPlayer();
    }
}


