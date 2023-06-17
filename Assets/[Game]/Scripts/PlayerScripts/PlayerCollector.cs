using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private AgentCloseAttack _agentCloseAttack;
    
    private SpriteRenderer _spriteRenderer;

    private PlayerScaleUp _playerScaleUp;
    
    public PlayerScaleUp PlayerScaleUp => _playerScaleUp ??= GetComponentInChildren<PlayerScaleUp>();
    public AgentCloseAttack AgentCloseAttack => _agentCloseAttack ??= GetComponent<AgentCloseAttack>();
    
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        RangeAttackPowerUp rangeAttackPowerUp = other.GetComponent<RangeAttackPowerUp>();

        if (collectible != null)
        {
            PlayerScaleUp.OnCollectiblePickup();
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
