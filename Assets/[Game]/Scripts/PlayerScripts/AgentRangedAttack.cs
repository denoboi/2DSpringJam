using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AgentRangedAttack : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    
    [SerializeField] public bool CanRangeAttack { get; set; }
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        
        
    }
}
