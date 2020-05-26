using Aether.Input;
using UnityEngine;

namespace Aether.Movement
{
    internal class PlayerMovementSystem : MovementSystem
    {
        #region Private Fields
        [SerializeField]
        private CameraPivot cameraPivot;
        #endregion

        #region MonoBehaviour
        private void Start()
        {
            SubscribeToInput();
        }

        private void OnDestroy()
        {
            UnsubscribeFromInput();
        }

        private void FixedUpdate()
        {
            Vector2 movementInput = InputSystem.InputActions.Player.Movement.ReadValue<Vector2>();
            Move(movementInput);
        }

        private void Update()
        {
            Vector2 lookInput = InputSystem.InputActions.Player.Look.ReadValue<Vector2>();

            Rotate(rotationInput: new Vector2(lookInput.x, 0));
            cameraPivot.Rotate(rotationInput: new Vector2(0, lookInput.y), rotationSpeed: RotationSpeed);
        }
        #endregion

        #region Input
        private void SubscribeToInput()
        {
            InputSystem.InputActions.Player.Jump.started += x => Jump();
        }

        private void UnsubscribeFromInput()
        {
            InputSystem.InputActions.Player.Jump.started -= x => Jump();
        }
        #endregion
    }
}
