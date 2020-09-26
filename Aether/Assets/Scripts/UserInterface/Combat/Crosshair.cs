using Aether.Combat.Player;
using Aether.Core;
using Aether.Input;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using Syc.Combat.TargetSystem;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField]
        private Animator crosshairAnimator;

        [SerializeField]
        private GameObject crosshairContainer;

        private ITargetManager _playerTargetSystem;
        
        private static readonly int HasObjectTarget = Animator.StringToHash("HasObjectTarget");

        private void Start()
        {
            if (Player.Instance.Has(out ICombatSystem combatSystem))
                _playerTargetSystem = combatSystem.Get<ITargetManager>();

            crosshairAnimator.keepAnimatorControllerStateOnDisable = true;
            InputSystem.OnActionMapSwitched += InputSystem_OnActionMapSwitched;
            
            crosshairContainer.SetActive(InputSystem.CurrentActionMap == ActionMap.Player);
        }

        private void OnDestroy()
        {
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
    }
}
