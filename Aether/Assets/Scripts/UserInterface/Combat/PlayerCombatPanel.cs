using System;
using Aether.Core;
using Syc.Combat;
using Syc.Combat.Auras;
using Syc.Combat.HealthSystem;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class PlayerCombatPanel : MonoBehaviour, ILocalPlayerLink
    {
        [SerializeField]
        protected TextMeshProUGUI nameText;

        [SerializeField]
        protected HealthBar healthBar;

        [SerializeField]
        protected AuraBar auraBar;

        public void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        public void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public void OnLocalPlayerLinked(Player player)
        {
            nameText.text = player.name;
            if (!player.Has(out ICombatSystem combatSystem))
                return;

            if (combatSystem.Has(out HealthSystem healthSystem))
                healthBar.SetHealth(healthSystem);

            if (combatSystem.Has(out AuraSystem auraSystem))
                auraBar.SetAuraSystem(auraSystem);
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            nameText.text = "no player found";

            healthBar.SetHealth(null);
            auraBar.SetAuraSystem(null);
        }
    }
}
