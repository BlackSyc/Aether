using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.TargetSystem
{
    public interface ICombatComponent
    {
        int AggroBias { get; }

        string Name { get; }

        T Get<T>();

        bool Has<T>(out T t);

        bool IsFriendly { get; }

        bool IsEnemy { get; }

        ITransform Transform { get; }

        bool IsIn(LayerMask layerMask);
        void TriggerGlobalAggro(int globalAggro);
    }
}
