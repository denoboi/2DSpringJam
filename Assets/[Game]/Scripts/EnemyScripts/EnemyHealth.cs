using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private GameObject collectiblePrefab;
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
        //TODO play death animation, play death sound, etc.
        Debug.Log("Enemy died.");
        Destroy(gameObject);
        var collectible = Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
    }
}
