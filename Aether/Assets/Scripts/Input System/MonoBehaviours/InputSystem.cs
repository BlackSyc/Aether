using System;
using UnityEngine;

namespace Aether.InputSystem
{
    public class InputSystem : MonoBehaviour
    {
        #region Static
        public static InputActions Input { get; private set; }

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
            if(Input != null)
            {
                Debug.LogWarning("There can only be 1 instance of Input Actions active!");
                Destroy(gameObject);
                return;
            }
            Input = new InputActions();
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
            Input.Player.SwapActionMap.performed += _ => SwitchToActionMap(ActionMap.UserInterface);
            Input.UserInterface.SwapActionMap.performed += _ => SwitchToActionMap(ActionMap.Player);
        }
        #endregion

        #region Public Static Methods
        public static void SwitchToActionMap(ActionMap actionMap)
        {
            switch (actionMap)
            {
                case ActionMap.Player:
                    Input.Player.Enable();
                    Input.UserInterface.Disable();
                    Input.PopUp.Disable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
                case ActionMap.UserInterface:
                    Input.Player.Disable();
                    Input.UserInterface.Enable();
                    Input.PopUp.Disable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
                case ActionMap.PopUp:
                    Input.Player.Disable();
                    Input.UserInterface.Disable();
                    Input.PopUp.Enable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
            }
        }
        #endregion
    }
}
