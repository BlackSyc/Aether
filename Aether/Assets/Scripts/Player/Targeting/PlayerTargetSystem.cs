using ScriptableObjects;
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

        private InputActions inputActions;

        private bool targetSelf = false;
        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            inputActions = new InputActions();
            SubscribeToInput();
        }

        private void OnEnable()
        {
            inputActions.Player.CastOnSelf.Enable();
        }

        private void OnDisable()
        {
            inputActions.Player.CastOnSelf.Disable();
        }
        #endregion

        #region Input
        private void SubscribeToInput()
        {
            inputActions.Player.CastOnSelf.started += _ => targetSelf = true;
            inputActions.Player.CastOnSelf.canceled += _ => targetSelf = false;
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
