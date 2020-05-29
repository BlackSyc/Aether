using Aether.Core;
using Aether.Core.Combat;
using Aether.Input;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class Crosshair : MonoBehaviour
    {

        [SerializeField]
        private Animator _crosshairAnimator;

        [SerializeField]
        private GameObject _crosshairContainer;

        [SerializeField]
        private Camera _camera;

        private ISpellSystem playerSpellSystem;

        private ITargetSystem playerTargetSystem;

        private void Start()
        {
            var playerCombatSystem = Player.Instance.Get<ICombatSystem>();
            playerSpellSystem = playerCombatSystem.Get<ISpellSystem>();
            playerTargetSystem = playerCombatSystem.Get<ITargetSystem>();

            _crosshairAnimator.keepAnimatorControllerStateOnDisable = true;
            _crosshairContainer.SetActive(false);
            InputSystem.OnActionMapSwitched += InputSystem_OnActionMapSwitched;
        }

        private void OnDestroy()
        {
            InputSystem.OnActionMapSwitched -= InputSystem_OnActionMapSwitched;
        }

        private void InputSystem_OnActionMapSwitched(ActionMap newActionMap)
        {
            _crosshairContainer.SetActive(newActionMap == ActionMap.Player && playerSpellSystem.HasActiveSpells);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            LayerMask layerMask = playerSpellSystem.GetCombinedLayerMask();

            if (playerTargetSystem.GetCurrentTarget(layerMask) != null)
            {
                _crosshairAnimator.SetBool("HasObjectTarget", true);
            }
            else
            {
                _crosshairAnimator.SetBool("HasObjectTarget", false);
            }
        }
    }
}
