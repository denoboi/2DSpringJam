using UnityEngine;


public class SkeletonHealth : MonoBehaviour
{
    private Animator _animator;
    private static readonly int isDead = Animator.StringToHash("isDead");
    [SerializeField] private int _currentHealth;
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] EnemyData _enemyData;
    
    private Animator Animator => _animator ??= GetComponent<Animator>();
    
    private void Start()
    {
        _currentHealth = _enemyData.HP;
    }
    
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        Animator.SetTrigger("GetHit");
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    
    
    private void Die()
    {
        Animator.SetBool(isDead, true);
        Destroy(gameObject);
        var collectible = Instantiate(collectiblePrefab, transform.position + Vector3.up / 2, Quaternion.identity);

    }
}