using Aether.Core;
using UnityEngine;

namespace Aether.Combat
{
    internal interface ICombatSystem : Core.Combat.ICombatSystem
    {
        int AggroBias { get; }

        bool IsFriendly { get; }

        bool IsEnemy { get; }

        bool IsIn(LayerMask layerMask);
    }
}
