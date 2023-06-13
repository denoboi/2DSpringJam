using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : MonoBehaviour
{
    private Animator _animator;
    
    public Animator SkeletonAnimator =>  _animator ??= GetComponent<Animator>();
    
    public void PlayAnimation(SkeletonAnimationState state)
    {
        switch (state)
        {
            case SkeletonAnimationState.Idle:
                Play("Idle");
                break;
            case SkeletonAnimationState.Run:
                Play("Run");
                break;
            case SkeletonAnimationState.Jump:
                Play("Jump");
                break;
            case SkeletonAnimationState.Fall:
                Play("Fall");
                break;
            case SkeletonAnimationState.Attack:
                Play("Attack");
                break;
            case SkeletonAnimationState.Dead:
                Play("Dead");
                break;
        }
    }
    
    public void Play(string name)
    {
        SkeletonAnimator.SetBool( name, true);
    }
    
    
    
    
}

public enum SkeletonAnimationState
{
    Idle,
    Run,
    Jump,
    Fall,
    Attack,
    Dead
}
