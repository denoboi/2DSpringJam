using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;
    [SerializeField]
    private int _currentHealth;


    #region HealthUI

    public int health;
    public int numofHealts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;





    #endregion
    public bool IsPlayerDead { get; private set; }
    
    private AgentAnimation _agentAnimation;
    public AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();
    

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        
        UIHealth();

       
    }

    private void UIHealth()
    {
        if (_currentHealth > numofHealts)
        {
            _currentHealth = numofHealts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < _currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }

        if (_currentHealth <= 0)
        {
            Die();
        }
    }


    
    public void TakeDamage(int damageAmount)
    {

      


        _currentHealth -= damageAmount;
        
        if(IsPlayerDead) 
            return;
        
        AgentAnimation.PlayTrigger("GetHit");

        Debug.Log("Player health + " +  _currentHealth);

       
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


