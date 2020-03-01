using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class ActionMapManager : MonoBehaviour
{

    [SerializeField]
    private PlayerInput playerInput;

    public void SwapActionMap(CallbackContext context)
    {
        if (context.performed)
        {
            if(playerInput.currentActionMap.name.Equals("Player"))
            {
                playerInput.SwitchCurrentActionMap("User Interface");
                Cursor.lockState = CursorLockMode.None;
            }
            else if (playerInput.currentActionMap.name.Equals("User Interface"))
            {
                playerInput.SwitchCurrentActionMap("Player");
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }
}
