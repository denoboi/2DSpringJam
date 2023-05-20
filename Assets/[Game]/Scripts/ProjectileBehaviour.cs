using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO bu scripte transform translate yapilabilir.
public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    private float Speed = 4.5f;
    public float rotationSpeed = 100f; // Adjust the speed of rotation as desired

    private void Start()
    {
        StartCoroutine(RotateProjectile());
    }
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }
    
    private IEnumerator RotateProjectile()
    {
        while (true)
        {
            //transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponentInChildren<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(20);
            Destroy(gameObject);
        }
            
        
        
    }
}