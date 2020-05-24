using ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.TargetSystem
{
    public class CombatSystem : MonoBehaviour, ICombatSystem
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

        [SerializeField]
        private List<MonoBehaviour> combatComponents;

        private CombatPanel combatPanel;
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
                ShowCombatToolTip();
        }
        #endregion


        #region Public Methods
        public T Get<T>()
        {
            return combatComponents.OfType<T>().SingleOrDefault();
        }

        public void ShowCombatToolTip()
        {
            combatPanel = Instantiate(combatPanelPrefab, transform).GetComponent<CombatPanel>();
        }

        public void HideCombatToolTip()
        {
            Destroy(combatPanel);
            combatPanel = null;
        }

        public bool Has<T>(out T t)
        {
            t = Get<T>();
            return t != null;
        }

        public void TriggerGlobalAggro(int globalAggro)
        {
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}
