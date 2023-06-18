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
        
        if(IsPlayerDead) 
            return;
        
        AgentAnimation.PlayTrigger("GetHit");

       
    }

    public void Die()
    {
        if(IsPlayerDead) 
            return;
        
        IsPlayerDead = true;
        AgentAnimation.PlayTrigger("Dead");
        EventManager.OnPlayerDead?.Invoke();
        Debug.Log("Player died.");
    }
    
    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public bool IsEnemyDead()
    {
        return IsPlayerDead;
    }
    

    
}


