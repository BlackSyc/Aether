using static Aether.InputSystem.GameInputSystem;
using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;


public class PlayerMovementSystem : MovementSystem
{
    #region Private Fields
    [SerializeField]
    private CameraPivot cameraPivot;
    #endregion

    #region MonoBehaviour
    protected override void Awake()
    {
        base.Awake();
        SubscribeToInput();
    }

    private void OnDestroy()
    {
        UnsubscribeFromInput();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = PlayerInput.Player.Movement.ReadValue<Vector2>();

        if (movementInput.magnitude > 0f)
        {
            IsMoving = true;
            Move(movementInput);
        }
        else
        {
            IsMoving = false;
        }
    }

    private void Update()
    {
        Vector2 lookInput = PlayerInput.Player.Look.ReadValue<Vector2>();

        Rotate(rotationInput: new Vector2(lookInput.x, 0));
        cameraPivot.Rotate(rotationInput: new Vector2(0, lookInput.y), rotationSpeed: RotationSpeed);
    }
    #endregion

    #region Input
    private void SubscribeToInput()
    {
        PlayerInput.Player.Jump.started += x => Jump();
    }

    private void UnsubscribeFromInput()
    {
        PlayerInput.Player.Jump.started -= x => Jump();
    }
    #endregion
}
