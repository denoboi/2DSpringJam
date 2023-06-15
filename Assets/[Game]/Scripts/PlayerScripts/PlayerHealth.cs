using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;
    [SerializeField]
    private int _currentHealth;
    
    private AgentAnimation _agentAnimation;
    public AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        

    }


    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        AgentAnimation.PlayTrigger("GetHit");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform actions when the player dies
        // For example, play death animation, show game over screen, etc.
        AgentAnimation.PlayAnimation(AgentAnimationState.Dead);
        EventManager.OnPlayerDead?.Invoke();
        Debug.Log("Player died.");
    }
}


