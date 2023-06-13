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
   
   private EnemyChase _enemyChase;
   
   private Transform targetPoint;
   private bool isMovingRight = true;

   
   Rigidbody2D Rb2D => _rb2d ??= GetComponent<Rigidbody2D>();
   EnemyChase EnemyChase => _enemyChase ??= GetComponent<EnemyChase>();

   private void Start()
   {
      targetPoint = pointB.transform;
   }
   
   private void Update()
   {
      Move();
   }
   
   private void Move()
   { 

     
      if(IsChasing())
         return;
      
      
      float direction = isMovingRight ? 1f : -1f;
      transform.Translate(Vector2.right * direction * _speed * Time.deltaTime);
      
      
      
      if (Vector2.Distance(transform.position, targetPoint.position) < 1f)
      {
         if (targetPoint == pointA.transform)
            SwitchTarget(pointB.transform);
         else
            SwitchTarget(pointA.transform);
      }
      
      
      
      
      
   }

   private void SwitchTarget(Transform newTarget)
   {
      targetPoint = newTarget;
      isMovingRight = !isMovingRight;
      FlipCharacter();
   }

   private void FlipCharacter()
   {
      Vector3 scale = transform.localScale;
      scale.x *= -1;
      transform.localScale = scale;
   }

   private bool IsChasing()
   {
      EnemyChase enemyChase = GetComponent<EnemyChase>();
      return enemyChase != null && enemyChase.IsChasing;
   }

      
   
   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere( pointA.transform.position, .5f);
      Gizmos.DrawWireSphere( pointB.transform.position, .5f);
      Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
      
   }
}
