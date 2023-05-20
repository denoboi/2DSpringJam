using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    [SerializeField] private float _speed = 1.5f;
    
    EnemyAttack _enemyAttack;

    [SerializeField] private bool _shouldMove = true;
    
    public EnemyAttack EnemyAttack => _enemyAttack ??= GetComponent<EnemyAttack>();
    private GameObject _player;

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
        
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
       
    }
    
    public void StopMoving()
    {
        _shouldMove = false;
    }

    public void StartMoving()
    {
        _shouldMove = true;
    }
    

    
}
