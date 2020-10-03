using Syc.Combat.Auras;
using Syc.Combat.HealthSystem;
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
        protected AuraBar auraBar;

        [SerializeField]
        protected TextEmitter textEmitter;

        [SerializeField]
        protected PlayerTargetIndicator playerTargetIndicator;

        [SerializeField]
        protected Castbar castBar;

        private Transform _cameraTransform;

        public CombatPanel SetInfo(CombatPanelInfo info)
        {
            this.combatPanelInfo = info;
            return this;
        }

        private void Start()
        {
            if (!(Camera.main is null))
            {
                _cameraTransform = Camera.main.transform;
            }

            if (nameText != null)
                nameText.text = combatPanelInfo.CombatSystem?.Origin.name;

            if (healthBar != null)
                LinkHealthBar();

            if (textEmitter != null)
                LinkTextEmitter();

            if (auraBar != null)
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
            if (combatPanelInfo.CombatSystem.Has(out AuraSystem auraSystem))
                auraBar.SetAuraSystem(auraSystem);
            else
                auraBar.enabled = false;
        }

        protected virtual void LateUpdate()
        {
            transform.position = transform.parent.position + combatPanelInfo.PanelOffset;

            transform.rotation = Quaternion.LookRotation(_cameraTransform.forward, _cameraTransform.up);
            float distanceToCamera = Vector3.Distance(transform.position, _cameraTransform.position);

            canvasGroup.alpha = distanceToCamera - 3;
        }
    }
}
