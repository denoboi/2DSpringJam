using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private AgentAnimation _agentAnimation;
    private SpriteRenderer _spriteRenderer;

    #region Props
    public Rigidbody2D Rb2D => _rigidbody ??= GetComponent<Rigidbody2D>();
    public PlayerInput PlayerInput => _playerInput ??= GetComponentInParent<PlayerInput>();
    
    public AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
    #endregion
  
    private void Start()
    {
        PlayerInput.OnMovement += HandleMovement;
    }
    

    private void HandleMovement(Vector2 input)
    {
        
        if (Mathf.Abs(input.x) > 0)
        {
            if (Mathf.Abs(Rb2D.velocity.x) < 0.01f)
            {
                AgentAnimation.PlayAnimation(AgentAnimationState.Run);
                
            }
            Rb2D.velocity = new Vector2(input.x * 5, Rb2D.velocity.y);
        }
        else
        {
            if (Mathf.Abs(Rb2D.velocity.x) > 0)
            {
                AgentAnimation.PlayAnimation(AgentAnimationState.Idle);
            }
            Rb2D.velocity = new Vector2(0, Rb2D.velocity.y);
        }
        
        ChangeFaceDirection(input);
    }

    private void ChangeFaceDirection(Vector2 input)
    {
        if(input.x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if(input.x < 0)
        {
            SpriteRenderer.flipX = true;
        }
    }
}