using UnityEngine;

namespace Aether.Movement
{
    public interface IMovementSystem : Core.Movement.IMovementSystem
    {
        #region Public Properties
        float RotationSpeed { get; }

        float JumpPower { get; set; }

        bool IsMoving { get; }
        #endregion

        #region Public Methods
        void Jump();
        void Move(Vector2 movementInput);
        void Rotate(Vector2 rotationInput);
        #endregion
    }
}