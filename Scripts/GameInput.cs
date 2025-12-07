using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System;


public class GameInput : MonoBehaviour

{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions PlayerInputActions;

    public event EventHandler OnPlayerAttack;

    private void Awake()
    {
        Instance = this;

        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Enable();

        PlayerInputActions.Combat.Attack.started += PlayerAttack_started;
    }
    private void PlayerAttack_started(InputAction.CallbackContext obj)
    {
           OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = PlayerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector; }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }
    }
    


