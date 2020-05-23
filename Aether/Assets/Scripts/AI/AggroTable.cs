using Aether.TargetSystem;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AggroTable : MonoBehaviour, AggroManager
{
    [SerializeField]
    private float aggroRange;

    private List<(int aggro, ICombatComponent target)> aggroTargets = new List<(int, ICombatComponent)>();

    public bool Contains(ICombatComponent target)
    {
        return aggroTargets.Any(x => x.target == target);
    }

    public (int aggro, ICombatComponent target) GetHighestAggroTarget(LayerMask layerMask)
    {
        return aggroTargets
            .Where(x => x.target.IsIn(layerMask))
            .FirstOrDefault(x => x.aggro == aggroTargets
                .Max(y => y.aggro));
    }

    public void AddAggroTarget(ICombatComponent target)
    {
        if (gameObject.IsFriendly() ? target.IsFriendly : target.IsEnemy)
            return;

        if (Contains(target))
            return;

        Debug.Log($"Aggro Target '{target.Name}' added to Aggro Table '{gameObject.name}'!");


        aggroTargets.Add((target.AggroBias, target));
    }

    public void RemoveAggroTarget(ICombatComponent target)
    {
        aggroTargets.RemoveAll(x => x.target == target);
    }

    public void IncreaseAggro(ICombatComponent target, int amount)
    {
        if (!aggroTargets.Any(x => x.target == target))
            return;


        (int aggro, ICombatComponent target) currentEntry = aggroTargets.Single(x => x.target == target);

        aggroTargets.Remove(currentEntry);
        aggroTargets.Add((currentEntry.aggro + amount, target));
    }

    public void DecreaseAggro(ICombatComponent target, int amount)
    {
        if (!aggroTargets.Any(x => x.target == target))
            return;


        (int aggro, ICombatComponent trigger) currentEntry = aggroTargets.Single(x => x.target == target);

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
            .Select(x => x.GetComponent<ICombatComponent>())
            .Where(x => x != null)
            .Where(x => !Contains(x))
            .ForEach(x => AddAggroTarget(x));
    }

    public ICombatComponent GetCurrentTarget(LayerMask layerMask)
    {
        (int aggro, ICombatComponent target) highestAggroTarget = GetHighestAggroTarget(layerMask);

        if (highestAggroTarget.target != null)
        {
            return highestAggroTarget.target;
        }

        return null;
    }
}
