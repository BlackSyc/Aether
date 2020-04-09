using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private float rotationSpeed = 10;

    [SerializeField]
    private float jumpPower = 5;

    private Vector3 movementInput;
    private float upwardsMovement = 0;

    public bool IsMoving => movementInput.magnitude > 0;

    private CharacterController characterController;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        Vector3 localMovement = (transform.right * movementInput.x + transform.forward * movementInput.y) * movementSpeed;
        localMovement.y = upwardsMovement;

        if (!characterController.isGrounded)
        {
            // Add our gravity Vector
            localMovement += Physics.gravity * Time.fixedDeltaTime;
        }

        upwardsMovement = localMovement.y;

        characterController.Move(localMovement * Time.fixedDeltaTime);
    }

    // Gets called from PlayerInput when the movement action is triggered.
    // Contains a Vector2 for the movement direction.
    public void Move(CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void Jump(CallbackContext context)
    {
        if (context.started && characterController.isGrounded)
        {
            upwardsMovement = jumpPower;
        }
    }

    public void Rotate(CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        Vector3 localRotation = transform.up * lookInput.x * rotationSpeed;
        transform.Rotate(localRotation * Time.deltaTime, Space.World);
    }
}
