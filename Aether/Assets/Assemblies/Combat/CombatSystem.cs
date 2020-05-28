using Aether.Core;
using Aether.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Combat
{
    public class CombatSystem : CoreSystemBehaviour, ICombatSystem
    {
        #region Private Fields
        [SerializeField]
        private GameObject combatPanelPrefab;

        [SerializeField]
        private Vector3 panelOffset;

        [SerializeField]
        private bool showCombatPanelOnStart = true;

        [SerializeField]
        private int aggroBias;

        private GameObject combatPanel;
        #endregion

        #region Public Properties
        public string Name => gameObject.name;

        public ITransform Transform { get; private set; }

        public Vector3 PanelOffset => panelOffset;

        public int AggroBias => aggroBias;

        public bool IsFriendly => Layers.FriendlyLayer.Contains(gameObject);

        public bool IsEnemy => Layers.EnemyLayer.Contains(gameObject);

        public bool IsIn(LayerMask layerMask) => layerMask == (layerMask | (1 << gameObject.layer));
        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            Transform = new ITransform(base.transform);
        }

        private void Start()
        {
            if (showCombatPanelOnStart)
                CreateCombatPanel();
        }
        #endregion

        #region Public Methods

        public void CreateCombatPanel()
        {
            combatPanel = Instantiate(combatPanelPrefab, transform);
        }

        public void HideCombatPanel()
        {
            Destroy(combatPanel);
            combatPanel = null;
        }

        public void TriggerGlobalAggro(int globalAggro)
        {
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}
