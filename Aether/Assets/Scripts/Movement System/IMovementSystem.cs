using UnityEngine;

public interface IMovementSystem
{
    #region Public Properties
    float MovementSpeed { get; }

    float RotationSpeed { get; }

    float JumpPower { get; }

    bool IsMoving { get; }
    #endregion

    #region Public Methods
    void Jump();
    void Move(Vector2 movementInput);
    void Rotate(Vector2 rotationInput);
    #endregion
}