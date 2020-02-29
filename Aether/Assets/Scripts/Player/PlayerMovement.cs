using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    private CharacterController characterController;
    private Vector2 movementInput;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        Vector3 localMovement = (transform.right * movementInput.x + transform.forward * movementInput.y) * movementSpeed;

        if (!characterController.isGrounded)
        {
            // Add our gravity Vector
            localMovement += Physics.gravity;
        }

        characterController.Move(localMovement * Time.deltaTime);
    }

    // Gets called from PlayerInput when the movement action is triggered.
    // Contains a Vector2 for the movement direction.
    public void Move(CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
