using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    private SpriteRenderer _spriteRenderer;
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectible collectible = other.GetComponent<Collectible>();

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
        playerData.Damage += playerBonusDamage;
    }

   
   
}
