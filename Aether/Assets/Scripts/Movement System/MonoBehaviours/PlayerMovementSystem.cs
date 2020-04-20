using static Aether.InputSystem.InputSystem;
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
        Vector2 movementInput = Aether.InputSystem.InputSystem.Input.Player.Movement.ReadValue<Vector2>();
        Move(movementInput);
    }

    private void Update()
    {
        Vector2 lookInput = Aether.InputSystem.InputSystem.Input.Player.Look.ReadValue<Vector2>();

        Rotate(rotationInput: new Vector2(lookInput.x, 0));
        cameraPivot.Rotate(rotationInput: new Vector2(0, lookInput.y), rotationSpeed: RotationSpeed);
    }
    #endregion

    #region Input
    private void SubscribeToInput()
    {
        Aether.InputSystem.InputSystem.Input.Player.Jump.started += x => Jump();
    }

    private void UnsubscribeFromInput()
    {
        Aether.InputSystem.InputSystem.Input.Player.Jump.started -= x => Jump();
    }
    #endregion
}
