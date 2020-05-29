using Aether.Core;
using Aether.Core.Combat;
using Aether.Input;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class DeathPanel : MonoBehaviour
    {
        private void Start()
        {
            Player.Instance.Get<ICombatSystem>().Get<IHealth>().OnDied += Show;
            gameObject.SetActive(false);
            GetComponent<CanvasGroup>().alpha = 1;
        }

        private void Show()
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
            Player.Instance.Get<ICombatSystem>().Get<IHealth>().OnDied -= Show;
        }
    }
}
