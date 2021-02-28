using Aether.Core;
using Aether.Input;
using Syc.Combat;
using Syc.Combat.TargetSystem;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class Crosshair : MonoBehaviour, ILocalPlayerLink
    {
        [SerializeField]
        private Animator crosshairAnimator;

        [SerializeField]
        private GameObject crosshairContainer;

        private ITargetManager _playerTargetSystem;
        
        private static readonly int HasObjectTarget = Animator.StringToHash("HasObjectTarget");

        private void Awake()
        {
            crosshairAnimator.keepAnimatorControllerStateOnDisable = true;
            InputSystem.OnActionMapSwitched += InputSystem_OnActionMapSwitched;
            Player.LinkToLocalPlayer(this);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
            InputSystem.OnActionMapSwitched -= InputSystem_OnActionMapSwitched;
        }

        private void InputSystem_OnActionMapSwitched(ActionMap newActionMap)
        {
            crosshairContainer.SetActive(newActionMap == ActionMap.Player);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (_playerTargetSystem == default)
                return;

            crosshairAnimator.SetBool(HasObjectTarget, _playerTargetSystem.CreateTarget().IsCombatTarget);
        }

        public void OnLocalPlayerLinked(Player player)
        {
            if (player.Has(out ICombatSystem combatSystem))
                _playerTargetSystem = combatSystem.Get<ITargetManager>();

            crosshairContainer.SetActive(InputSystem.CurrentActionMap == ActionMap.Player);
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            _playerTargetSystem = null;
            crosshairContainer.SetActive(false);
        }
    }
}
