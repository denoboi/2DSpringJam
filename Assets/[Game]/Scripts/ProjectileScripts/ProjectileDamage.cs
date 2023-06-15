using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private int _projectileDamage = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyHealth enemy = other.gameObject.GetComponentInChildren<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(_projectileDamage);
            Destroy(gameObject);
        }
    }
}
