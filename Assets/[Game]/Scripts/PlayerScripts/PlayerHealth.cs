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

    private void OnEnable()
    {
        EventManager.OnPlayerDead.AddListener(Die);
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDead.RemoveListener(Die);

    }


    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform actions when the player dies
        // For example, play death animation, show game over screen, etc.
        
        Debug.Log("Player died.");
    }
}


