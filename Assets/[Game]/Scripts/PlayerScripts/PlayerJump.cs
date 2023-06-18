using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")] [SerializeField]
    private float _jumpTime = 0.5f;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _jumpMultiplier = 2f;
    [SerializeField] bool _isJumping;

    private float _jumpCounter;

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
    public bool CanDoubleJump { get; set; }
    private void Start()
    {
        _vecGravity = new Vector2(0, Physics2D.gravity.y);
    }

    private void Update()
    {
        
        
        
        if (Input.GetButtonDown("Jump"))
            HandleJump();
        HandleFall();


        if (Rb2D.velocity.y > 0 && _isJumping)
        {
            JumpHigher();
        }

        if (Input.GetButtonUp("Jump"))
        {
            SmoothAscend();
        }
    }

    private void HandleJump()
    {
        if (!GroundDetector.IsGrounded) return;


        if (CanDoubleJump)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, _jumpForce * 1.6f);
            _isJumping = true;
            AgentAnimation.PlayTrigger("Fly");
        }
            

        else
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, _jumpForce);
            _isJumping = true;
            AgentAnimation.PlayTrigger("Jump");
        }
       
    }

    private void JumpHigher()
    {
        // this is the time that the player is holding the jump button
        _jumpCounter += Time.deltaTime;
        if (_jumpCounter > _jumpTime) _isJumping = false;

        float t = _jumpCounter / _jumpTime;
        float currentJumpMultiplier = _jumpMultiplier;

        if (t > 0.5f)
        {
            currentJumpMultiplier = _jumpMultiplier * (1 - t);
        }


        Rb2D.velocity += Vector2.up * Physics2D.gravity.y * currentJumpMultiplier * Time.deltaTime;
    }

    void SmoothAscend()
    {
        _isJumping = false;
        _jumpCounter = 0;

        if (Rb2D.velocity.y > 0)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, Rb2D.velocity.y * 0.5f);
        }
    }

    private void HandleFall()
    {
        if (Rb2D.velocity.y < 0)
        {
            // Apply the fall multiplier to increase the fall speed
            Rb2D.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
    }
}