using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementSystem : MonoBehaviour, IMovementSystem
{
    #region Private Fields
    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private float rotationSpeed = 10;

    [SerializeField]
    private float jumpPower = 5;

    private CharacterController characterController;

    private float upwardsMovement = 0;
    #endregion

    #region Public Properties
    public bool IsMoving = false;

    public float MovementSpeed => movementSpeed;

    public float RotationSpeed => rotationSpeed;

    public float JumpPower => jumpPower;
    #endregion

    #region MonoBehaviour
    protected virtual void Awake()
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
