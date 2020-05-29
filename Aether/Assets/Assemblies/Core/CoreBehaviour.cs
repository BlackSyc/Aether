using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Core
{
    [Serializable]
    public abstract class CoreSystemBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected List<UnityEngine.Object> exposedObjects;

        public T Get<T>()
        {
            return exposedObjects.OfType<T>().SingleOrDefault();
        }

        public bool Has<T>(out T t)
        {
            t = Get<T>();
            return t != null;
        }

        public bool Has<T>()
        {
            return exposedObjects.OfType<T>().Any();
        }
    }
}
