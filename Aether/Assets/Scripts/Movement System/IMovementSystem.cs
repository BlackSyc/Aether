using UnityEngine;

public interface IMovementSystem
{
    #region Public Properties
    float MovementSpeed { get; set; }

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