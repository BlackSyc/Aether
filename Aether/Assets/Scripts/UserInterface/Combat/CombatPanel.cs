using Aether.Core;
using Syc.Combat.HealthSystem;
using Syc.Combat.ModifierSystem;
using Syc.Combat.SpellSystem;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Combat
{

    public class CombatPanel : MonoBehaviour
    {
        private CombatPanelInfo combatPanelInfo;

        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        protected TextMeshProUGUI nameText;

        [SerializeField]
        protected HealthBar healthBar;

        [SerializeField]
        protected ModifiersBar modifiersBar;

        [SerializeField]
        protected TextEmitter textEmitter;

        [SerializeField]
        protected PlayerTargetIndicator playerTargetIndicator;

        [SerializeField]
        protected Castbar castBar;


        public CombatPanel SetInfo(CombatPanelInfo info)
        {
            this.combatPanelInfo = info;
            return this;
        }

        private void Start()
        {
            if (nameText != null)
                nameText.text = combatPanelInfo.CombatSystem.Origin.name;

            if (healthBar != null)
                LinkHealthBar();

            if (textEmitter != null)
                LinkTextEmitter();

            if (modifiersBar != null)
                LinkModifiersBar();

            if (playerTargetIndicator != null)
                LinkPlayerTargetIndicator();

            if (castBar != null)
                LinkCastbar();

        }

        private void LinkCastbar()
        {
            if (combatPanelInfo.CombatSystem.Has(out CastingSystem castingSystem))
                castBar.SetCastingSystem(castingSystem);
            else
                castBar.enabled = false;
        }

        protected void LinkPlayerTargetIndicator()
        {
            playerTargetIndicator.SetCombatSystem(combatPanelInfo.CombatSystem);
        }

        protected void LinkHealthBar()
        {
            if (combatPanelInfo.CombatSystem.Has(out HealthSystem healthSystem))
                healthBar.SetHealth(healthSystem);
            else
                healthBar.enabled = false;
        }

        protected void LinkTextEmitter()
        {
            if (combatPanelInfo.CombatSystem.Has(out HealthSystem healthSystem))
                textEmitter.SetHealth(healthSystem);
            else
                textEmitter.enabled = false;
        }

        protected void LinkModifiersBar()
        {
            if (combatPanelInfo.CombatSystem.Has(out ModifierSystem modifierSystem))
                modifiersBar.SetModifierSystem(modifierSystem);
            else
                modifiersBar.enabled = false;
        }

        protected virtual void LateUpdate()
        {
            transform.position = transform.parent.position + combatPanelInfo.PanelOffset;

            transform.rotation = Quaternion.LookRotation(Player.Instance.Get<Camera>().transform.forward, Player.Instance.Get<Camera>().transform.up);

            float distanceToCamera = Vector3.Distance(transform.position, Player.Instance.Get<Camera>().transform.position);

            canvasGroup.alpha = distanceToCamera - 3;
        }
    }
}
