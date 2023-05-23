using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator _animator;
    
    #region Props
    public Animator Animator => _animator ??= GetComponent<Animator>();
    #endregion
    
    
    public void PlayAnimation(AgentAnimationState state)
    {
        switch (state)
        {
            case AgentAnimationState.Idle:
                Play("Idle");
                break;
            case AgentAnimationState.Run:
                Play("Run");
                break;
            case AgentAnimationState.Jump:
                Play("Jump");
                break;
            case AgentAnimationState.Fall:
                Play("Fall");
                break;
            case AgentAnimationState.Attack:
                Play("Attack");
                break;
            case AgentAnimationState.Dead:
                Play("Dead");
                break;
        }
    }

    public void Play(string name)
    {
        Animator.Play(name, -1, 0f);
    }
    
    public void PlayTrigger(string name)
    {
        Animator.SetTrigger(name);
    }
}

public enum AgentAnimationState
{
    Idle,
    Run,
    Jump,
    Fall,
    Attack,
    Dead
}
