using static Aether.Input.InputSystem;
using UnityEngine;
using Aether.Input;

namespace Aether.UserInterface.Effects {
    public class CustomCursor : MonoBehaviour
    {
        #region MonoBehaviour
        private void Awake()
        {
            OnActionMapSwitched += ActionMapSwitched;
        }

        private void Update()
        {
            Cursor.visible = false;
            if (CurrentActionMap == ActionMap.UserInterface)
                transform.position = InputSystem.InputActions.UserInterface.MoveCursor.ReadValue<Vector2>();

            if (CurrentActionMap == ActionMap.PopUp)
                transform.position = InputSystem.InputActions.PopUp.MoveCursor.ReadValue<Vector2>();
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
}
