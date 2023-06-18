using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPU : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DoubleJumpController doubleJumpController = collision.GetComponent<DoubleJumpController>();
           PlayerJump playerJump = collision.GetComponent<PlayerJump>();
            if (doubleJumpController != null)
            {
                    playerJump.CanDoubleJump = true;
                 // playerJump.CanDoubleJump = true;
                 // Increase the max jumps to 3 after collecting the power-up
                Destroy(gameObject);
            }
        }
    }
}
