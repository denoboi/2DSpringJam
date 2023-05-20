using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleUp : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
    private Vector3 _initialScale;
    private void Awake()
    {
        _initialScale = transform.localScale;
    }
    
    public void OnCollectiblePickup()
    {
        float scaleMultiplier = 1.2f; // Modify this value to adjust the scale increase
        ScaleUpCharacter(scaleMultiplier);
    }
    
    private void ScaleUpCharacter(float scaleFactor)
    {
        Vector3 newScale = _initialScale * scaleFactor;
        transform.localScale = newScale;
    }
    
    
}
