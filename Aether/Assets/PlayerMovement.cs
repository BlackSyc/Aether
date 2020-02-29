using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    private CharacterController characterController;
    private Vector2 movementInput;


    void Awake()
    {
        this.characterController = this.GetComponent<CharacterController>();
    }

    // Gets called from PlayerInput when the movement action is triggered.
    // Contains a Vector2 for the movement direction.
    public void Move(CallbackContext context)
    {
        this.movementInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 localMovement = transform.right * movementInput.x + transform.forward * movementInput.y;
        characterController.Move(localMovement * movementSpeed * Time.deltaTime);
    }
}
