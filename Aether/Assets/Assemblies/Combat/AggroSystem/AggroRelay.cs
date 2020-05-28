using Aether.Combat;
using UnityEngine;

namespace Aether.Combat.AggroSystem
{
    internal class AggroRelay : MonoBehaviour, IAggroManager
    {
        public IAggroManager AggroManager;

        public void AddAggroTarget(ICombatSystem target)
        {
            if (AggroManager == null)
                return;

            AggroManager.AddAggroTarget(target);
        }

        public bool Contains(ICombatSystem target)
        {
            if (AggroManager == null)
                return false;

            return AggroManager.Contains(target);
        }

        public void DecreaseAggro(ICombatSystem target, int amount)
        {
            if (AggroManager == null)
                return;

            AggroManager.DecreaseAggro(target, amount);
        }

        public (int aggro, ICombatSystem target) GetHighestAggroTarget(LayerMask layerMask)
        {
            if (AggroManager == null)
                return (0, null);

            return AggroManager.GetHighestAggroTarget(layerMask);
        }

        public void IncreaseAggro(ICombatSystem target, int amount)
        {
            IncreaseAggro(target, amount);
        }

        public void IncreaseAggro(Core.Combat.ICombatSystem target, int amount)
        {
            if (AggroManager == null)
                return;

            AggroManager.IncreaseAggro(target, amount);
        }

        public void RemoveAggroTarget(ICombatSystem target)
        {
            if (AggroManager == null)
                return;

            AggroManager.RemoveAggroTarget(target);
        }
    }
}
