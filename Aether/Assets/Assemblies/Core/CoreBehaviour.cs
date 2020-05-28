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
        protected List<object> exposedObjects;

        public T Get<T>()
        {
            return exposedObjects.OfType<T>().SingleOrDefault();
        }

        public bool Has<T>(out T t)
        {
            t = Get<T>();
            return t != null;
        }
    }
}
