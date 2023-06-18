using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyKnockBack : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D ??= GetComponent<Rigidbody2D>();
    
   
    [SerializeField] private float knockBackForce, delay = 0.15f;
    
    public UnityEvent OnBeginKnockBack, OnEndKnockBack;
    
    public void PlayKnockBack(GameObject sender)
    {
        StopAllCoroutines();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        Rigidbody2D.AddForce(direction * knockBackForce, ForceMode2D.Impulse);
       // transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        OnBeginKnockBack?.Invoke();
        StartCoroutine(Reset());
    }
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        Rigidbody2D.velocity = Vector2.zero;
        OnEndKnockBack?.Invoke();
    }
}
