using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    public Sprite[] fireballSprites;
    public float frameRate = 0.1f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(AnimateFireball());
    }

    private IEnumerator AnimateFireball()
    {
        while (true)
        {
            for (int i = 0; i < fireballSprites.Length; i++)
            {
                spriteRenderer.sprite = fireballSprites[i];
                yield return new WaitForSeconds(frameRate);
            }
        }
    }
}
