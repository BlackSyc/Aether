using Aether.Core;
using Syc.Combat;
using Syc.Combat.Auras;
using Syc.Combat.HealthSystem;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class PlayerCombatPanel : MonoBehaviour
    {
        [SerializeField]
        protected TextMeshProUGUI nameText;

        [SerializeField]
        protected HealthBar healthBar;

        [SerializeField]
        protected AuraBar auraBar;

        public void Start()
        {
            nameText.text = Player.Instance.name;
            if (!Player.Instance.Has(out ICombatSystem combatSystem))
                return;

            if (combatSystem.Has(out HealthSystem healthSystem))
                healthBar.SetHealth(healthSystem);

            if (combatSystem.Has(out AuraSystem auraSystem))
                auraBar.SetAuraSystem(auraSystem);
        }
    }
}
