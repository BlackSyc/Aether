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

        private void Start()
        {
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
            _crosshairContainer.SetActive(newActionMap == ActionMap.Player && Player.Instance.CombatSystem.Get<ISpellSystem>().HasActiveSpells);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            LayerMask layerMask = Player.Instance.CombatSystem.Get<ISpellSystem>().GetCombinedLayerMask();

            if (Player.Instance.CombatSystem.Get<ITargetSystem>().GetCurrentTarget(layerMask) != null)
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
