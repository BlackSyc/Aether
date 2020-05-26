using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aether.Core
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Loaders/Layers")]
    public class Layers : ScriptableObject
    {
        [SerializeField]
        private LayerMask obstructionLayer;

        [SerializeField]
        private LayerMask friendlyLayer;

        [SerializeField]
        private LayerMask enemyLayer;

        public static LayerMask ObstructionLayer { get; private set; }

        public static LayerMask FriendlyLayer { get; private set; }

        public static LayerMask EnemyLayer { get; private set; }

        private void OnEnable()
        {
            ObstructionLayer = obstructionLayer;
            FriendlyLayer = friendlyLayer;
            EnemyLayer = enemyLayer;
        }
    }
}
