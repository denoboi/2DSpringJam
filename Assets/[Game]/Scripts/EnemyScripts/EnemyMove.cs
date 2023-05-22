using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    [field:SerializeField]
    public float Speed { get; set; }
    [SerializeField] private bool _shouldMove = true;

    private EnemyAnimation _enemyAnimation;
    private GameObject _player;
    private static readonly int Move = Animator.StringToHash("Move");

    public EnemyAnimation EnemyAnimation => _enemyAnimation ??= GetComponentInChildren<EnemyAnimation>();

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        if (_player == null) return;
        if(!_shouldMove) return;
        
        float moveValue = Mathf.Abs(transform.position.x - _player.transform.position.x);
        EnemyAnimation.Animator.SetFloat(Move, moveValue);
       
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);
       
    }

  
    
    public void StopMoving()
    {
        _shouldMove = false;
        EnemyAnimation.Animator.SetFloat(Move, 0f);
        
       
    }

    public void StartMoving()
    {
        _shouldMove = true;
        
    }
    

    
}
