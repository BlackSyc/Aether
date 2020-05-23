using ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.TargetSystem
{
    public class Target : MonoBehaviour, ITarget
    {

        private void Awake()
        {
            Transform = new ITransform(base.transform);
        }

        [SerializeField]
        private int aggroBias;

        public int AggroBias => aggroBias;

        [SerializeField]
        private List<MonoBehaviour> objects;


        public T Get<T>()
        {
            return objects.OfType<T>().SingleOrDefault();
        }
        public bool IsFriendly => Layers.FriendlyLayer.Contains(gameObject);

        public ITransform Transform { get; private set; }

        public bool IsEnemy => Layers.EnemyLayer.Contains(gameObject);

        public bool IsIn(LayerMask layerMask) => layerMask == (layerMask | (1 << gameObject.layer));

        public string Name => gameObject.name;

        public bool Has<T>(out T t)
        {
            t = Get<T>();
            return t != null;
        }

        public void TriggerGlobalAggro(int globalAggro)
        {
            //throw new System.NotImplementedException();
        }
    }
}
