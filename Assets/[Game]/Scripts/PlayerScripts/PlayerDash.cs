using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashForce = 20f; // The force of the dash
    [SerializeField] private float dashDuration = 0.5f; // The duration of the dash
    private Rigidbody2D rb; // The player's rigidbody

    public bool IsDashing { get; set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !IsDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        IsDashing = true;

        // Apply the dash force
        rb.velocity = new Vector2(dashForce * transform.localScale.x, rb.velocity.y);

        // Wait for the dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset the velocity to stop the dash
        rb.velocity = new Vector2(0f, rb.velocity.y);

        IsDashing = false;
    }
}


