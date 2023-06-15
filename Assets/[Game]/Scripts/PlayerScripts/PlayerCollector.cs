using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private AgentCloseAttack _agentCloseAttack;
    
    private SpriteRenderer _spriteRenderer;
    
    public AgentCloseAttack AgentCloseAttack => _agentCloseAttack ??= GetComponent<AgentCloseAttack>();
    
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        RangeAttackPowerUp rangeAttackPowerUp = other.GetComponent<RangeAttackPowerUp>();

        if (collectible != null)
        {
            // Apply the bonus damage to the player
            ApplyBonusDamage(collectible.GetBonusDamage());

            // Destroy the collectible item
            Destroy(collectible.gameObject);
        }
        
      
    }
    
    private void ApplyBonusDamage(int playerBonusDamage)
    {
        AgentCloseAttack.DamageValue += playerBonusDamage;
    }

   
   
}
