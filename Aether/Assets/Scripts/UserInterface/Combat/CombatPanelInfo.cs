using Aether.Core.Combat;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    [RequireComponent(typeof(ICombatSystem))]
    public class CombatPanelInfo : MonoBehaviour
    {

        public ICombatSystem CombatSystem { get; private set; }

        private CombatPanel combatPanel;


        [SerializeField]
        private GameObject combatPanelPrefab;

        [SerializeField]
        private bool showCombatPanelOnStart;

        public Vector3 PanelOffset;

        public Vector3 PanelScale;

        private void Start()
        {
            CombatSystem = GetComponent<ICombatSystem>();

            if (showCombatPanelOnStart)
                ShowCombatPanel();
        }

        public void ShowCombatPanel()
        {
            if (combatPanel == null)
                CreateCombatPanel();

            combatPanel.gameObject.SetActive(true);
        }

        public void HideCombatPanel()
        {
            combatPanel.gameObject.SetActive(false);
        }

        private void CreateCombatPanel()
        {
            combatPanel = Instantiate(combatPanelPrefab, transform)
                .GetComponent<CombatPanel>()
                .SetInfo(this);
        }
    }
}
