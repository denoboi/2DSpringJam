using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    private int _damage = 5;
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
    
    [SerializeField] private EnemyData _data;
    
    private void Start()
    {
        _player = PlayerManager.Instance.Player.transform;
        if(_player == null)
            Debug.LogError("Player not found");
       
        SetSkeletonValues();
    }
    

    private void Update()
    {
        CheckDistance();
    }
    
    void SetSkeletonValues()
    {
        _damage = _data.Damage;
        EnemyPatrol._speed = _data.Speed;
    }


    void CheckDistance()
    {
        float distanceToPlayer = Vector2.Distance(transform.position,
            _player.transform.position);
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
       
        SkeletonAnimation.SkeletonAnimator.SetTrigger(Attack1);
        
        // Wait for the attack delay
        yield return new WaitForSeconds(_attackRate);

        // Stop attack animation
        // Example: GetComponent<Animator>().ResetTrigger("Attack");
        SkeletonAnimation.SkeletonAnimator.SetTrigger(Idle);
        _isAttacking = false;
       
    }
    
    private void Hit() //Animation Event
    {
        float distanceToPlayer = Vector2.Distance(transform.position, 
            _player.transform.position);
        if (distanceToPlayer <= _attackRange)
        {
           
            // Apply damage to the player or trigger any other desired effects
            Debug.Log("Skeleton attacked player");
            _player.GetComponentInChildren<PlayerHealth>().TakeDamage(_damage);
            _player.GetComponentInChildren<AgentAnimation>().Animator.SetTrigger("GetHit");
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

   
}


