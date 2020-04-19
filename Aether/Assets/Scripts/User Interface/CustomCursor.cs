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
        GameInputSystem.OnActionMapSwitched += ActionMapSwitched;
    }

    private void Update()
    {
        if (GameInputSystem.CurrentActionMap == ActionMap.UserInterface)
            transform.position = GameInputSystem.PlayerInput.UserInterface.MoveCursor.ReadValue<Vector2>();

        if (GameInputSystem.CurrentActionMap == ActionMap.PopUp)
            transform.position = GameInputSystem.PlayerInput.PopUp.MoveCursor.ReadValue<Vector2>();
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
