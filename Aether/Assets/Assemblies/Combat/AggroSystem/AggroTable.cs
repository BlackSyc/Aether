using Aether.Combat;
using Aether.Combat.Health;
using Aether.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Combat.AggroSystem
{
    internal class AggroTable : MonoBehaviour, IAggroManager
    {
        [SerializeField]
        private float aggroRange;

        private List<(int aggro, ICombatSystem target)> aggroTargets = new List<(int, ICombatSystem)>();

        public bool Contains(ICombatSystem target)
        {
            return aggroTargets.Any(x => x.target == target);
        }

        public (int aggro, ICombatSystem target) GetHighestAggroTarget(LayerMask layerMask)
        {
            return aggroTargets
                .Where(x => x.target.IsIn(layerMask))
                .FirstOrDefault(x => x.aggro == aggroTargets
                    .Max(y => y.aggro));
        }

        public void AddAggroTarget(ICombatSystem target)
        {
            if (gameObject.IsFriendly() ? target.IsFriendly : target.IsEnemy)
                return;

            if (Contains(target))
                return;

            Debug.Log($"Aggro Target '{target.Name}' added to Aggro Table '{gameObject.name}'!");


            aggroTargets.Add((target.AggroBias, target));
        }

        public void RemoveAggroTarget(ICombatSystem target)
        {
            aggroTargets.RemoveAll(x => x.target == target);
        }

        public void IncreaseAggro(ICombatSystem target, int amount)
        {
            if (!aggroTargets.Any(x => x.target == target))
                return;


            (int aggro, ICombatSystem target) currentEntry = aggroTargets.Single(x => x.target == target);

            aggroTargets.Remove(currentEntry);
            aggroTargets.Add((currentEntry.aggro + amount, target));
        }

        public void DecreaseAggro(ICombatSystem target, int amount)
        {
            if (!aggroTargets.Any(x => x.target == target))
                return;


            (int aggro, ICombatSystem trigger) currentEntry = aggroTargets.Single(x => x.target == target);

            aggroTargets.Remove(currentEntry);
            aggroTargets.Add((currentEntry.aggro - amount, target));
        }

        private void Update()
        {
            RemoveDeadTargets();
            LookForNewTargets();
        }

        private void RemoveDeadTargets()
        {
            aggroTargets.RemoveAll(x => x.target == null || x.target.Get<IHealth>().IsDead);
        }

        private void LookForNewTargets()
        {
            Physics.OverlapSphere(transform.position, aggroRange, gameObject.EnemyLayer())
                .Select(x => x.GetComponent<ICombatSystem>())
                .Where(x => x != null)
                .Where(x => !Contains(x))
                .ForEach(x => AddAggroTarget(x));
        }

        public ICombatSystem GetCurrentTarget(LayerMask layerMask)
        {
            (int aggro, ICombatSystem target) highestAggroTarget = GetHighestAggroTarget(layerMask);

            if (highestAggroTarget.target != null)
            {
                return highestAggroTarget.target;
            }

            return null;
        }
    }
}
