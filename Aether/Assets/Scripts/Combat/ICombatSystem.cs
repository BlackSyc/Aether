using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Combat
{
    public interface ICombatSystem
    {
        int AggroBias { get; }

        string Name { get; }

        T Get<T>();

        bool Has<T>(out T t);

        bool IsFriendly { get; }

        bool IsEnemy { get; }

        ITransform Transform { get; }
        Vector3 PanelOffset { get; }

        bool IsIn(LayerMask layerMask);
        void TriggerGlobalAggro(int globalAggro);
    }
}
