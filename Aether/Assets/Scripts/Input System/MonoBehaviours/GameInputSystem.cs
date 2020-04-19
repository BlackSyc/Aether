using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Aether.InputSystem
{
    public class GameInputSystem : MonoBehaviour
    {
        #region Static
        public static InputActions PlayerInput { get; private set; }

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
            if(PlayerInput != null)
            {
                Debug.LogWarning("There can only be 1 instance of Input Actions active!");
                Destroy(gameObject);
                return;
            }
            PlayerInput = new InputActions();
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
            PlayerInput.Player.SwapActionMap.performed += _ => SwitchToActionMap(ActionMap.UserInterface);
            PlayerInput.UserInterface.SwapActionMap.performed += _ => SwitchToActionMap(ActionMap.Player);
        }
        #endregion

        #region Public Static Methods
        public static void SwitchToActionMap(ActionMap actionMap)
        {
            switch (actionMap)
            {
                case ActionMap.Player:
                    PlayerInput.Player.Enable();
                    PlayerInput.UserInterface.Disable();
                    PlayerInput.PopUp.Disable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
                case ActionMap.UserInterface:
                    PlayerInput.Player.Disable();
                    PlayerInput.UserInterface.Enable();
                    PlayerInput.PopUp.Disable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
                case ActionMap.PopUp:
                    PlayerInput.Player.Disable();
                    PlayerInput.UserInterface.Disable();
                    PlayerInput.PopUp.Enable();
                    CurrentActionMap = actionMap;
                    OnActionMapSwitched?.Invoke(actionMap);
                    break;
            }
        }
        #endregion
    }
}
