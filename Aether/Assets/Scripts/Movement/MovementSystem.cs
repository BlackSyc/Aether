using UnityEngine;

namespace Aether.Movement
{
    [RequireComponent(typeof(CharacterController))]
    internal class MovementSystem : MonoBehaviour, IMovementSystem
    {
        #region Private Fields

        [SerializeField]
        private float rotationSpeed = 10;

        private CharacterController _characterController;

        private float _upwardsMovement;
        #endregion

        #region Public Properties
        public bool IsMoving { get; private set; }

        public float MovementSpeed { get; set; } = 8;

        public float RotationSpeed => rotationSpeed;

        public float JumpPower { get; set; } = 5;
        
        public bool IsActive { get; set; } = true;
        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
        #endregion

        #region Public Methods
        public void Move(Vector2 movementInput)
        {
            if (!IsActive)
                return;

            Vector3 localMovement = (transform.right * movementInput.x + transform.forward * movementInput.y) * MovementSpeed;
            IsMoving = localMovement.magnitude > 0.01f;

            localMovement.y = _upwardsMovement;

            if (!_characterController.isGrounded)
                localMovement += Physics.gravity * Time.fixedDeltaTime;

            _upwardsMovement = localMovement.y;

            _characterController.Move(localMovement * Time.fixedDeltaTime);

        }

        public void Jump()
        {
            if (!IsActive)
                return;

            if (_characterController.isGrounded)
                _upwardsMovement = JumpPower;
        }

        public void Rotate(Vector2 rotationInput)
        {
            if (!IsActive)
                return;

            Vector3 localRotation = (transform.up * rotationInput.x + transform.right * rotationInput.y) * RotationSpeed;
            transform.Rotate(localRotation * Time.deltaTime, Space.World);
        }
        #endregion
    }
}
