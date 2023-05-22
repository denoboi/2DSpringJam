using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
   private Animator _animator;
   
   public Animator Animator =>  _animator ??= GetComponent<Animator>();
   
   public void PlayAnimation(EnemyAnimationState state)
   {
      switch (state)
      {
         case EnemyAnimationState.Idle:
            Play("Idle");
            break;
         case EnemyAnimationState.Run:
            Play("Run");
            break;
         case EnemyAnimationState.Jump:
            Play("Jump");
            break;
         case EnemyAnimationState.Fall:
            Play("Fall");
            break;
         case EnemyAnimationState.Attack:
            Play("Attack");
            break;
         case EnemyAnimationState.Dead:
            Play("Dead");
            break;
      }
   }
   
   public void Play(string name)
   {
      Animator.SetBool( name, true);
   }
   
   public void Stop(string name)
   {
      Animator.SetBool( name, false);
   }
   
   
   
   
}

public enum EnemyAnimationState
{
   Idle,
   Run,
   Jump,
   Fall,
   Attack,
   Dead
}
