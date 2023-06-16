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
    
    public bool IsPlayerDead { get; private set; }
    
    private AgentAnimation _agentAnimation;
    public AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();
    

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void TakeDamage(int damageAmount)
    {
        if (_currentHealth <= 0)
        {
            Die();
            return;
        }
        
        _currentHealth -= damageAmount;
        AgentAnimation.PlayTrigger("GetHit");

       
    }

    private void Die()
    {
        // Perform actions when the player dies
        // For example, play death animation, show game over screen, etc.
        EventManager.OnPlayerDead?.Invoke();
        AgentAnimation.PlayTrigger("Dead");
        IsPlayerDead = true;
        Debug.Log("Player died.");
    }

    
}


