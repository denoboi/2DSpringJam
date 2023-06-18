using UnityEngine;

public class DoubleJumpController : MonoBehaviour
{
    public float jumpForce = 5f;
    public int maxJumps = 2; // Set this to 2 to enable double jump
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    public bool CanDoubleJump { get; set; } 
    private bool isGrounded;
    private int jumpCount;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!CanDoubleJump)
            return;
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || jumpCount < maxJumps)
            {
                Jump();
                jumpCount++;
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}