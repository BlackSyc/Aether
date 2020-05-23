using static Aether.InputSystem.InputSystem;
using ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

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
        private void Start()
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
            InputSystem.InputSystem.Input.Player.CastOnSelf.started += _ => targetSelf = true;
            InputSystem.InputSystem.Input.Player.CastOnSelf.canceled += _ => targetSelf = false;
        }

        private void UnsubscribeFromInput()
        {
            InputSystem.InputSystem.Input.Player.CastOnSelf.started -= _ => targetSelf = true;
            InputSystem.InputSystem.Input.Player.CastOnSelf.canceled -= _ => targetSelf = false;
        }
        #endregion

        #region Public Methods
        public ITarget GetCurrentTarget(LayerMask layerMask)
        {
            if (targetSelf && layerMask.Contains(gameObject))
                return GetComponent<ITarget>();

            return Physics.RaycastAll(playerCamera.position, playerCamera.forward, maxRange)
                .Where(x => x.transform != transform)
                .Select(x => (x, x.transform.GetComponent<ITarget>()))
                .Where(x => x.Item2 != null)
                .Select(x => x.Item2)
                .SingleOrDefault();
        }
        #endregion
    }
}
