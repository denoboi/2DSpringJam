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
   
   #region Props
   public Rigidbody2D Rb2D => _rigidbody ??= GetComponent<Rigidbody2D>();
   public PlayerInput PlayerInput => _playerInput ??= GetComponentInParent<PlayerInput>();

   public GroundDetector GroundDetector => _groundDetector ??= GetComponentInChildren<GroundDetector>();
   
   public AgentAnimation AgentAnimation => _agentAnimation ??= GetComponentInChildren<AgentAnimation>();
   #endregion
   
   private void Start()
   {
      PlayerInput.OnJumpPressed += HandleJump;
   }
   
   private void HandleJump()
   {
      if (!GroundDetector.IsGrounded ) return;
      Rb2D.velocity = new Vector2(Rb2D.velocity.x, _jumpForce);
      
      _isJumping = true;
      
      
   
      //TODO - Play jump animation
      AgentAnimation.PlayTrigger("Jump");
      //AgentAnimation.PlayAnimation(AgentAnimationState.Jump);
      
   }
   
   
}


