using Aether.Core;
using Aether.Input;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class DeathPanel : MonoBehaviour
    {
        private void Start()
        {
            Player.Instance.Get<ICombatSystem>().Get<HealthSystem>().OnDied += Show;
            gameObject.SetActive(false);
            GetComponent<CanvasGroup>().alpha = 1;
        }

        private void Show(DamageRequest _)
        {
            gameObject.SetActive(true);
            InputSystem.SwitchToActionMap(ActionMap.PopUp);
        }

        public void Respawn()
        {
            Player.Instance.Respawn();
            gameObject.SetActive(false);
            InputSystem.SwitchToActionMap(ActionMap.Player);
        }

        private void OnDestroy()
        {
            Player.Instance.Get<ICombatSystem>().Get<HealthSystem>().OnDied -= Show;
        }
    }
}
