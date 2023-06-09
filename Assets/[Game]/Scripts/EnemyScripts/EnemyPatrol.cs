using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   public GameObject pointA;
   public GameObject pointB;
   public float _speed = 2f;
   private Rigidbody2D _rb2d;
   private Transform _targetPoint;
   private EnemyChase _enemyChase;
   
   Rigidbody2D Rb2D => _rb2d ??= GetComponent<Rigidbody2D>();
   EnemyChase EnemyChase => _enemyChase ??= GetComponent<EnemyChase>();

   private void Start()
   {
      _targetPoint = pointB.transform;
      
   }
   
   private void Update()
   {
      Move();
   }
   
   private void Move()
   {
     
      if(EnemyChase.IsChasing)
         return;
      
      Vector2 point = _targetPoint.position - transform.position;

      if (_targetPoint == pointB.transform)
      {
        Rb2D.velocity = new Vector2(_speed, 0);
      }
      else
      {
         Rb2D.velocity = new Vector2(-_speed, 0); 
      }
         

      if (Vector2.Distance(transform.position, _targetPoint.position) < 1f && _targetPoint == pointB.transform)
      {
         Flip();
         _targetPoint = pointA.transform;
         
      }
      if (Vector2.Distance(transform.position, _targetPoint.position) < 1f && _targetPoint == pointA.transform) 
      {
         Flip();
         _targetPoint = pointB.transform;
      }
      
   }
   
   private void Flip()
   {
      Vector3 localScale = transform.localScale;
      localScale.x *= -1;
      transform.localScale = localScale;
   }

   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere( pointA.transform.position, .5f);
      Gizmos.DrawWireSphere( pointB.transform.position, .5f);
      Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
      
   }
}
