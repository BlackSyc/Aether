using Aether.Core;
using UnityEngine;

namespace Aether.Combat
{
    internal interface ICombatSystem : Core.Combat.ICombatSystem
    {
        int AggroBias { get; }

        bool IsFriendly { get; }

        bool IsEnemy { get; }

        ITransform Transform { get; }

        bool IsIn(LayerMask layerMask);

        void TriggerGlobalAggro(int globalAggro);
    }
}
