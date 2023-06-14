using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _attackRate = 1f;
    [SerializeField] private float _attackRange = 3f;

    public bool CanAttack { get; private set; }
    
    private Transform _player;
    private bool _isAttacking;
    private Rigidbody2D _rigidbody2D;
    private SkeletonAnimation _skeletonAnimation;
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private EnemyPatrol _enemyPatrol;
    
    public Rigidbody2D Rigidbody2D => _rigidbody2D ??= GetComponent<Rigidbody2D>();
    public SkeletonAnimation SkeletonAnimation => _skeletonAnimation ??= GetComponent<SkeletonAnimation>();
    public EnemyPatrol EnemyPatrol => _enemyPatrol ??= GetComponent<EnemyPatrol>();
    
    
    private void Start()
    {
        _player = PlayerManager.Instance.Player.transform;
        if(_player == null)
            Debug.LogError("Player not found");
       
    }

    private void Update()
    {
        CheckDistance();
    }


    void CheckDistance()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        if (distanceToPlayer <= _attackRange)
        {
            Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            EnemyPatrol._speed = 0;
            CanAttack = true;
            Attack();
        }
        else if (distanceToPlayer > _attackRange)
        {
            EnemyPatrol._speed = 2;
            Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            CanAttack = false;
        }
    }
    
    void Attack()
    {
        if (_isAttacking)
            return;
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        _isAttacking = true;

        // Play attack animation
        // Use your own animation system or Unity's Animator
        // Example: GetComponent<Animator>().SetTrigger("Attack");
        SkeletonAnimation.SkeletonAnimator.SetTrigger(Attack1);
        // Wait for the attack delay
        yield return new WaitForSeconds(_attackRate);

        // Check if the player is still within attacking range
        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        if (distanceToPlayer <= _attackRange)
        {
           
            // Apply damage to the player or trigger any other desired effects
            Debug.Log("Skeleton attacked player");
            
            
        }
        

        // Stop attack animation
        // Example: GetComponent<Animator>().ResetTrigger("Attack");
        SkeletonAnimation.SkeletonAnimator.SetTrigger(Idle);
        _isAttacking = false;
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}


