using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerScaleUp : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;


    public Collider2D Collider2D => _collider2D ??= GetComponentInChildren<Collider2D>();
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponent<SpriteRenderer>();
    private Vector3 _initialScale;
    private Vector3 _originalColliderScale;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private void Awake()
    {
        _initialScale = transform.localScale;
        if (Collider2D == null)
        {
            Debug.LogError("Collider2D is null");
        }
        else
            _originalColliderScale = Collider2D.transform.localScale;
    }


    public void OnCollectiblePickup()
    {
        float scaleMultiplier = 1.1f; // Modify this value to adjust the scale increase
        ScaleUpCharacter(scaleMultiplier);
        ScaleUpCollider();
        ChangeCameraSize();
    }

    private void ScaleUpCharacter(float scaleFactor)
    {
        Vector3 newScale = transform.localScale * scaleFactor;
        
        newScale.y = Mathf.Clamp(newScale.x, 5f, 12f);
        newScale.x = Mathf.Clamp(newScale.y, 5f, 12f);
        
        transform.localScale = newScale;
    }

    private void ScaleUpCollider()
    {
        Vector3 newColliderScale = Collider2D.transform.localScale += Vector3.Scale(_originalColliderScale,
            new Vector3(0.1f, 0.1f, 1f));
        newColliderScale.x = Mathf.Clamp(newColliderScale.x, 0.1f, 0.17f);
        newColliderScale.y = Mathf.Clamp(newColliderScale.y, 0.1f, 0.17f);
        
        Collider2D.transform.localScale = newColliderScale;
    }
    
    public void ChangeCameraSize()
    {
        if(transform.localScale.x > 9f)
            EventManager.OnPlayerSizeChanged.Invoke();
    }
}