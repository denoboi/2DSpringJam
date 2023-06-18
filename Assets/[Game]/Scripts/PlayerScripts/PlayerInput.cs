using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [field: SerializeField] public Vector2 MovementVector { get; private set; }

    public event Action OnAttack, OnJumpPressed, OnJumpReleased, OnWeaponSwitch;
    public event Action<Vector2> OnMovement;
    
    private PlayerHealth _playerHealth;
    public PlayerHealth PlayerHealth => _playerHealth ??= GetComponentInChildren<PlayerHealth>();

    public KeyCode jumpKey, attackKey, menuKey;
    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if(PlayerHealth.IsPlayerDead) return;
        GetAttackInput();
        GetJumpInput();
        GetMovementInput();
        GetWeaponSwitchInput();
        
        GetMenuInput();
    }

    private void GetMovementInput()
    {
        MovementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMovement?.Invoke(MovementVector);
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            //OnJumpPressed?.Invoke();
        }
    }

    private void GetAttackInput()
    {
        if (Input.GetKeyDown(attackKey))
        {
            OnAttack?.Invoke();
        }
    }

    private void GetWeaponSwitchInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnWeaponSwitch?.Invoke();
        }
    }
    
    private void GetMenuInput()
    {
        if (Input.GetKeyDown(menuKey))
        {
            OnMenuKeyPressed?.Invoke();
        }
    }
}