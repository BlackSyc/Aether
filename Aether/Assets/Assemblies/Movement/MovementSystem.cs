using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Movement
{
    [RequireComponent(typeof(CharacterController))]
    internal class MovementSystem : MonoBehaviour, IMovementSystem
    {
        #region Private Fields

        [SerializeField]
        private float rotationSpeed = 10;

        private CharacterController characterController;

        private float upwardsMovement = 0;
        #endregion

        #region Public Properties
        public bool IsMoving { get; private set; } = false;

        public float MovementSpeed { get; set; } = 8;

        public float RotationSpeed => rotationSpeed;

        public float JumpPower { get; set; } = 5;

        public ICombatSystem CombatSystem { get; set; }
        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }
        #endregion

        #region Public Methods
        public void Move(Vector2 movementInput)
        {
            Vector3 localMovement = (transform.right * movementInput.x + transform.forward * movementInput.y) * MovementSpeed;
            IsMoving = localMovement.magnitude > 0.01f;

            localMovement.y = upwardsMovement;

            if (!characterController.isGrounded)
                localMovement += Physics.gravity * Time.fixedDeltaTime;

            upwardsMovement = localMovement.y;

            characterController.Move(localMovement * Time.fixedDeltaTime);

        }

        public void Jump()
        {
            if (characterController.isGrounded)
                upwardsMovement = JumpPower;
        }

        public void Rotate(Vector2 rotationInput)
        {
            Vector3 localRotation = (transform.up * rotationInput.x + transform.right * rotationInput.y) * RotationSpeed;
            transform.Rotate(localRotation * Time.deltaTime, Space.World);
        }
        #endregion
    }
}
