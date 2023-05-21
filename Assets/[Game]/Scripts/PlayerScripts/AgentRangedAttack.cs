using System;
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
        if(!CanRangeAttack) return;
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RangeAttackPowerUp rangeAttackPowerUp = other.GetComponent<RangeAttackPowerUp>();

        if (rangeAttackPowerUp != null)
        {
            CanRangeAttack = true;
            Destroy(other.gameObject);
        }
    }
}
