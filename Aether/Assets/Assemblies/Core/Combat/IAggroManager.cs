using UnityEngine;

namespace Aether.Core.Combat
{
    public interface IAggroManager
    {
        void IncreaseAggro(ICombatSystem target, int amount);
    }
}
