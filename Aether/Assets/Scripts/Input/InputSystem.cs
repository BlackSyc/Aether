using System;
using UnityEngine;

namespace Aether.Input
{
    public class InputSystem : MonoBehaviour
    {
        #region Static
        public static InputActions InputActions { get; private set; }

        public static event Action<ActionMap> OnActionMapSwitched;
        public static ActionMap CurrentActionMap { get; private set; }

        #endregion

        #region Private Fields
        [SerializeField]
        private ActionMap defaultActionMap;
        #endregion


        #region MonoBehaviour
        private void Awake()
        {
            if(InputActions != null)
            {
                Debug.LogWarning("There can only be 1 instance of Input Actions active!");
                Destroy(gameObject);
                return;
            }
            InputActions = new InputActions();
        }

        private void Start()
        {
            SwitchToActionMap(defaultActionMap);
            SubscribeToInputActions();
        }
        #endregion

        #region Input
        private void SubscribeToInputActions()
        {
            InputActions.Player.SwapActionMap.performed += _ => SwitchToActionMap(ActionMap.UserInterface);
            InputActions.UserInterface.SwapActionMap.performed += _ => SwitchToActionMap(ActionMap.Player);
        }
        #endregion

        #region Public Static Methods
        public static void SwitchToActionMap(ActionMap actionMap)
        {
            switch (actionMap)
            {
                case ActionMap.Player:
                    InputActions.Player.Enable();
                    InputActions.UserInterface.Disable();
                    InputActions.PopUp.Disable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
                case ActionMap.UserInterface:
                    InputActions.Player.Disable();
                    InputActions.UserInterface.Enable();
                    InputActions.PopUp.Disable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
                case ActionMap.PopUp:
                    InputActions.Player.Disable();
                    InputActions.UserInterface.Disable();
                    InputActions.PopUp.Enable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
            }
        }
        #endregion
    }
}
