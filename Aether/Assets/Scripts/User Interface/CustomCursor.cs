using Aether.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CustomCursor : MonoBehaviour
{
    #region MonoBehaviour
    private void Awake()
    {
        Cursor.visible = false;
        Aether.InputSystem.InputSystem.OnActionMapSwitched += ActionMapSwitched;
    }

    private void Update()
    {
        if (Aether.InputSystem.InputSystem.CurrentActionMap == ActionMap.UserInterface)
            transform.position = Aether.InputSystem.InputSystem.Input.UserInterface.MoveCursor.ReadValue<Vector2>();

        if (Aether.InputSystem.InputSystem.CurrentActionMap == ActionMap.PopUp)
            transform.position = Aether.InputSystem.InputSystem.Input.PopUp.MoveCursor.ReadValue<Vector2>();
    }
    #endregion

    #region Private Methods
    private void ActionMapSwitched(ActionMap newActionMap)
    {
        switch (newActionMap)
        {
            case ActionMap.Player:
                Cursor.lockState = CursorLockMode.Locked;
                gameObject.SetActive(false);
                break;
            case ActionMap.UserInterface:
                Cursor.lockState = CursorLockMode.None;
                gameObject.SetActive(true);
                break;
            case ActionMap.PopUp:
                Cursor.lockState = CursorLockMode.None;
                gameObject.SetActive(true);
                break;
        }
    }
    #endregion
}
