using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   
   [SerializeField] private float _jumpForce = 5f;
   [SerializeField] private float _fallMultiplier = 2.5f;
   
   [SerializeField]  bool _isJumping;

   private GroundDetector _groundDetector;
   private Rigidbody2D _rigidbody;
   private PlayerInput _playerInput; 
   private AgentAnimation _agentAnimation;
   private Vector2 _vecGravity;
   
   #region Props
   public Rigidbody2D Rb2D => _rigidbody ??= GetComponent<Rigidbody2D>();
   public PlayerInput PlayerInput => _playerInput ??= GetComponentInParent<PlayerInput>();

   public GroundDetector GroundDetector => _groundDetector ??= GetComponentInChildren<GroundDetector>();
   
   public AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();
   #endregion
   
   private void Start()
   {
      _vecGravity = new Vector2(0, Physics2D.gravity.y);
      PlayerInput.OnJumpPressed += HandleJump;
      PlayerInput.OnJumpPressed += HandleFall;
   }
   
   private void HandleJump()
   {
      if (!GroundDetector.IsGrounded) return;
      Rb2D.velocity = new Vector2(Rb2D.velocity.x, _jumpForce);
      _isJumping = true;

      AgentAnimation.PlayTrigger("Jump");

      if (Rb2D.velocity.y < 0)
      {
         // Apply the fall multiplier to increase the fall speed
         Rb2D.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
      }
     
      
   }

   private void HandleFall()
   {
     
      //else if (Rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
      // {
      //    Rb2D.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
      // }
   }
   
   
}


