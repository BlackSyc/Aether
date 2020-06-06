using Aether.Core.Extensions;
using Aether.Input;
using System.Linq;
using UnityEngine;

namespace Aether.Combat.TargetSystem
{
    internal class PlayerTargetSystem : MonoBehaviour, ITargetSystem
    {
        #region Private Fields

        [SerializeField]
        private Transform playerCamera;

        [SerializeField]
        private float maxRange = 100f;

        private bool targetSelf = false;

        public ICombatSystem CombatSystem { get; set; }
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
            InputSystem.InputActions.Player.CastOnSelf.started += _ => targetSelf = true;
            InputSystem.InputActions.Player.CastOnSelf.canceled += _ => targetSelf = false;
        }

        private void UnsubscribeFromInput()
        {
            InputSystem.InputActions.Player.CastOnSelf.started -= _ => targetSelf = true;
            InputSystem.InputActions.Player.CastOnSelf.canceled -= _ => targetSelf = false;
        }
        #endregion

        #region Public Methods
        public ICombatSystem GetCurrentTarget(LayerMask layerMask)
        {
            if (targetSelf && layerMask.Contains(gameObject))
                return GetComponent<ICombatSystem>();

            return Physics.RaycastAll(playerCamera.position, playerCamera.forward, maxRange)
                .Where(x => x.transform != transform)
                .Select(x => (x, x.transform.GetComponent<ICombatSystem>()))
                .Where(x => x.Item2 != null)
                .Select(x => x.Item2)
                .OrderBy(x => Vector3.Distance(x.Transform.Position, playerCamera.position))
                .FirstOrDefault();
        }

        public Vector3 GetCurrentTargetExact(LayerMask layerMask)
        {
            var combatTargetPoint = Physics.RaycastAll(playerCamera.position, playerCamera.forward, maxRange)
                .Where(x => x.transform != transform)
                .Select(x => (x, x.transform.GetComponent<ICombatSystem>()))
                .Where(x => x.Item2 != null)
                .OrderBy(x => Vector3.Distance(x.Item2.Transform.Position, playerCamera.position))
                .Select(x => x.x.point)
                .FirstOrDefault();

            if (combatTargetPoint != null)
                return combatTargetPoint;

            return transform.position + (transform.forward.normalized * maxRange);

        }

        Core.Combat.ICombatSystem Core.Combat.ITargetSystem.GetCurrentTarget(LayerMask layerMask)
        {
            return GetCurrentTarget(layerMask);
        }
        #endregion
    }
}
