using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] EnemyData _enemyData;
    [SerializeField] private bool destroyOnDeath = true;
    
    
    private Animator _animator;
   
    
    private void Start()
    {
        _currentHealth = _enemyData.HP;
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
        //TODO play enemy death animation, play death sound, etc.
        
       
        Destroy(gameObject);
        var collectible = Instantiate(collectiblePrefab, transform.position + Vector3.up, Quaternion.identity);
        
        
        
           
    }
    
}
