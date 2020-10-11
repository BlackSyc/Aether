using Syc.Combat;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    [RequireComponent(typeof(CombatMonoSystem))]
    public class CombatPanelInfo : MonoBehaviour
    {

        public ICombatSystem CombatSystem { get; private set; }

        private CombatPanel _combatPanel;


        [SerializeField]
        private CombatPanel combatPanelPrefab;

        [SerializeField]
        private bool showCombatPanelOnStart;

        public Vector3 PanelOffset;

        public Vector3 PanelScale;

        private void Start()
        {
            CombatSystem = GetComponent<CombatMonoSystem>();

            if (CombatSystem == default)
                return;
            
            if (showCombatPanelOnStart)
                ShowCombatPanel();
        }

        public void ShowCombatPanel()
        {
            if (_combatPanel == null)
                CreateCombatPanel();

            _combatPanel.gameObject.SetActive(true);
        }

        public void HideCombatPanel()
        {
            _combatPanel.gameObject.SetActive(false);
        }

        private void CreateCombatPanel()
        {
            if (combatPanelPrefab != null)
            {
                _combatPanel = Instantiate(combatPanelPrefab, transform)
                    .SetInfo(this);
            }
        }
    }
}
