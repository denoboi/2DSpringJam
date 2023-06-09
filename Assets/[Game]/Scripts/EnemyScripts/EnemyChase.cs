using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float detectionRange = 7f;
    [SerializeField] private float chaseRange = 15f;
    [SerializeField] private float speed = 2f;

    public bool IsChasing {get; private set;}
    
    private void Start()
    {
        _player = PlayerManager.Instance.Player.transform;
        if(_player == null)
            Debug.LogError("Player not found");
       
    }
    private void Update()
    {
        Chase();
        
        if(IsChasing)
            FacePlayer();
        
        
    }

    private void Chase()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
          
        if (!IsChasing && distanceToPlayer <= detectionRange)
        {
            IsChasing = true;
        }

        if (IsChasing && distanceToPlayer > chaseRange)
        {
            IsChasing = false;
            
            
        }

        if (IsChasing)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            Vector2 movement = direction * speed * Time.deltaTime;
            transform.Translate(movement.x, 0, 0);
            
            
        }
    }

    void FacePlayer()
    {
        float direction = _player.position.x - transform.position.x;
        
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * (direction < 0 ? -1f : 1f);
        transform.localScale = localScale;
    }

   


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
