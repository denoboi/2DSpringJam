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

    [SerializeField] private EnemyData _data;
    
    private Transform _player;
    private EnemyMove _enemyMove;
    private bool _isAttacking;
    private bool _isPlayerAlive = true;

    private void OnEnable()
    {
        EventManager.OnPlayerDead.AddListener(StopAttacking);
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDead.RemoveListener(StopAttacking);
    }

    public EnemyMove EnemyMove => _enemyMove ??= GetComponent<EnemyMove>();

    private void Start()
    {
       _player = PlayerManager.Instance.Player.transform;
        SetEnemyValues();
    }

    void Update()
    {
        if (_isAttacking)
            return;

        if(!_isPlayerAlive)
            return;
        // Check if the enemy is within attacking range of the player
        CheckDistance();
    }

    private void SetEnemyValues()
    {
        _damage = _data.Damage;
        EnemyMove.Speed = _data.Speed;
    }

    void CheckDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        
        if (distanceToPlayer <= _attackRange)
        {
            Attack();
        }
        else if (distanceToPlayer > _attackRange)
        {
            EnemyMove.StartMoving();
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
            Debug.Log("player took damage.");
            EnemyMove.StopMoving();
        }
        

        // Stop attack animation
        // Example: GetComponent<Animator>().ResetTrigger("Attack");

        _isAttacking = false;
        EnemyMove.FollowPlayer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
    
    private void StopAttacking()
    {
        StopAllCoroutines();
        _isPlayerAlive = false;
    }
}


