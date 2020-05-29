﻿using Aether.Core;
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
        private int aggroBias;
        #endregion

        #region Public Properties
        public string Name => gameObject.name;

        public ITransform Transform { get; private set; }

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
        #endregion

        #region Public Methods

        public void TriggerGlobalAggro(int globalAggro)
        {
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}
