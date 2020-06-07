using Aether.Core.Combat;
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
        public Target GetCurrentTarget()
        {
            if (targetSelf)
                return new Target(GetComponent<ICombatSystem>());

            return Physics.RaycastAll(playerCamera.position, playerCamera.forward, maxRange)
                .Where(hit => hit.transform != transform)
                .Select(hit => (hit, hit.transform.GetComponent<ICombatSystem>()))
                .Where(hitTuple => hitTuple.Item2 != null)
                .Where(hitTuple => hitTuple.Item2.CanBeTargeted)
                .OrderBy(hitTuple => Vector3.Distance(hitTuple.hit.point, playerCamera.position))
                .Take(1)
                .Select(hitTuple => new Target(hitTuple.Item2, hitTuple.hit.point - hitTuple.Item2.Transform.Position))
                .DefaultIfEmpty(new Target(playerCamera.position + playerCamera.forward * maxRange))
                .FirstOrDefault();
        }
        #endregion
    }
}
