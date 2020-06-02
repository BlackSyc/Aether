using Aether.Core;
using Aether.Core.Combat;
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

        public CombatPanel SetInfo(CombatPanelInfo info)
        {
            this.combatPanelInfo = info;
            return this;
        }

        protected virtual void Start()
        {
            if (nameText != null)
                nameText.text = combatPanelInfo.CombatSystem.Name;

            if (healthBar != null)
                LinkHealthBar();

            if (modifiersBar != null)
                LinkModifiersBar();
        }

        protected void LinkHealthBar()
        {
            if (combatPanelInfo.CombatSystem.Has(out IHealth health))
                healthBar.SetHealth(health);
            else
                healthBar.enabled = false;
        }

        protected void LinkModifiersBar()
        {
            if (combatPanelInfo.CombatSystem.Has(out IModifierSlots modifierSlots))
                modifiersBar.SetModifierSlots(modifierSlots);
            else
                modifiersBar.enabled = false;
        }

        protected virtual void LateUpdate()
        {
            transform.position = transform.parent.position + combatPanelInfo.PanelOffset;
            //Debug.Log($"Camera: {Player.Instance.Get<Camera>().transform.forward}, Player: {Player.Instance.transform.forward}");
            transform.rotation = Quaternion.LookRotation(-Player.Instance.Get<Camera>().transform.forward, Player.Instance.Get<Camera>().transform.up);

            float distanceToCamera = Vector3.Distance(transform.position, Player.Instance.Get<Camera>().transform.position);

            canvasGroup.alpha = distanceToCamera - 3;
        }
    }
}
