using static Aether.InputSystem.GameInputSystem;
using ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Aether.TargetSystem
{
    public class PlayerTargetSystem : MonoBehaviour, ITargetSystem
    {
        #region Private Fields

        [SerializeField]
        private Transform playerCamera;

        [SerializeField]
        private float maxRange = 100f;

        private bool targetSelf = false;
        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            SubscribeToInput();
        }

        private void OnDestroy()
        {
            UnsubscribeFromInput();
        }
        #endregion

        #region Input
        private void SubscribeToInput()
        {
            InputSystem.GameInputSystem.PlayerInput.Player.CastOnSelf.started += _ => targetSelf = true;
            InputSystem.GameInputSystem.PlayerInput.Player.CastOnSelf.canceled += _ => targetSelf = false;
        }

        private void UnsubscribeFromInput()
        {
            InputSystem.GameInputSystem.PlayerInput.Player.CastOnSelf.started -= _ => targetSelf = true;
            InputSystem.GameInputSystem.PlayerInput.Player.CastOnSelf.canceled -= _ => targetSelf = false;
        }
        #endregion

        #region Public Methods
        public Target GetCurrentTarget(LayerMask layerMask)
        {
            if (targetSelf && layerMask.Contains(gameObject))
                return new Target(transform);


            bool hitFound = Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, maxRange, Layers.ObstructionLayer | layerMask);

            if (!hitFound)
                return new Target(playerCamera.position + playerCamera.forward * maxRange);

            if (Layers.ObstructionLayer.Contains(raycastHit.collider.gameObject))
                return new Target(raycastHit.point);

            return new Target(raycastHit.transform);
        }
        #endregion
    }
}
