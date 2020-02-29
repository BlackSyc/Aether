using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private float jumpPower;

    private CharacterController characterController;
    private Vector3 localMovement;


    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        if (!characterController.isGrounded)
        {
            // Add our gravity Vector
            localMovement += Physics.gravity * Time.fixedDeltaTime;
        }

        characterController.Move(localMovement * Time.fixedDeltaTime);
    }

    // Gets called from PlayerInput when the movement action is triggered.
    // Contains a Vector2 for the movement direction.
    public void Move(CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        float upwardsMovement = localMovement.y;
        localMovement = (transform.right * movementInput.x + transform.forward * movementInput.y) * movementSpeed;
        localMovement.y = upwardsMovement;
    }

    public void Jump(CallbackContext context)
    {
        if (context.started)
        {
            if (characterController.isGrounded)
            {
                localMovement.y = jumpPower;
            }
        }
    }
}
