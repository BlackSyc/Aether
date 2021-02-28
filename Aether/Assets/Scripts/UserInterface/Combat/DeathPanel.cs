using Aether.Core;
using Aether.Input;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class DeathPanel : MonoBehaviour, ILocalPlayerLink
    {
        private void Start()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void Show(DamageRequest _)
        {
            gameObject.SetActive(true);
            InputSystem.SwitchToActionMap(ActionMap.PopUp);
        }

        public void Respawn()
        {
            Player.Respawn();
            gameObject.SetActive(false);
            InputSystem.SwitchToActionMap(ActionMap.Player);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public void OnLocalPlayerLinked(Player player)
        {
            if (player.Has(out ICombatSystem combatSystem) 
                && combatSystem.Has(out HealthSystem healthSystem))
            {
                healthSystem.OnDied += Show;
            }
            
            gameObject.SetActive(false);
            GetComponent<CanvasGroup>().alpha = 1;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            if (player.Has(out ICombatSystem combatSystem) && combatSystem.Has(out HealthSystem healthSystem))
            {
                healthSystem.OnDied -= Show;
            }
        }
    }
}
