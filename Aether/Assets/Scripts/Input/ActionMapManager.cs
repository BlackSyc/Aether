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
                EnableUIActionMap();
            }
            else if (playerInput.currentActionMap.name.Equals("User Interface"))
            {
                EnablePlayerActionMap();
            }

        }
    }

    public void EnablePopUpActionMap()
    {
        playerInput.SwitchCurrentActionMap("PopUp");
        Cursor.lockState = CursorLockMode.None;
    }

    public void EnablePlayerActionMap()
    {
        playerInput.SwitchCurrentActionMap("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnableUIActionMap()
    {
        playerInput.SwitchCurrentActionMap("User Interface");
        Cursor.lockState = CursorLockMode.None;
    }
}
