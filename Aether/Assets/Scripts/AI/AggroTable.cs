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

    private List<(int aggro, AggroTrigger trigger)> aggroTriggers = new List<(int, AggroTrigger)>();

    public bool Contains(AggroTrigger trigger)
    {
        return aggroTriggers.Any(x => x.trigger == trigger);
    }

    public (int aggro, AggroTrigger trigger) GetHighestAggroTrigger(LayerMask layerMask)
    {
        return aggroTriggers
            .Where(x => layerMask.Contains(x.trigger.gameObject))
            .FirstOrDefault(x => x.aggro == aggroTriggers
                .Max(y => y.aggro));
    }

    public void AddAggroTrigger(AggroTrigger aggroTrigger)
    {
        if (gameObject.IsFriendly() ? aggroTrigger.gameObject.IsFriendly() : aggroTrigger.gameObject.IsEnemy())
            return;

        if (Contains(aggroTrigger))
            return;

        Debug.Log($"Aggro Trigger '{aggroTrigger.name}' added to Aggro Table '{gameObject.name}'!");
        aggroTriggers.Add((aggroTrigger.Bias, aggroTrigger));
        aggroTrigger.GlobalAggroRaised += x => IncreaseAggro(aggroTrigger, x);

    }

    public void RemoveAggroTrigger(AggroTrigger aggroTrigger)
    {
        aggroTrigger.GlobalAggroRaised -= x => IncreaseAggro(aggroTrigger, x);
        aggroTriggers.RemoveAll(x => x.trigger == aggroTrigger);
    }

    public void IncreaseAggro(AggroTrigger aggroTrigger, int amount)
    {
        if (!aggroTriggers.Any(x => x.trigger == aggroTrigger))
            return;


        (int aggro, AggroTrigger trigger) currentEntry = aggroTriggers.Single(x => x.trigger == aggroTrigger);

        aggroTriggers.Remove(currentEntry);
        aggroTriggers.Add((currentEntry.aggro + amount, aggroTrigger));
    }

    public void DecreaseAggro(AggroTrigger aggroTrigger, int amount)
    {
        if (!aggroTriggers.Any(x => x.trigger == aggroTrigger))
            return;


        (int aggro, AggroTrigger trigger) currentEntry = aggroTriggers.Single(x => x.trigger == aggroTrigger);

        aggroTriggers.Remove(currentEntry);
        aggroTriggers.Add((currentEntry.aggro - amount, aggroTrigger));
    }

    private void Update()
    {
        RemoveDeadTriggers();
        LookForNewTriggers();
    }

    private void RemoveDeadTriggers()
    {
        aggroTriggers.RemoveAll(x => !x.trigger || x.trigger.GetComponent<Health>().IsDead);
    }

    private void LookForNewTriggers()
    {
        Physics.OverlapSphere(transform.position, aggroRange, gameObject.EnemyLayer())
            .Select(x => x.GetComponent<AggroTrigger>())
            .Where(x => x != null)
            .Where(x => x.IsActive)
            .Where(x => !Contains(x))
            .ForEach(x => AddAggroTrigger(x));
    }

    public Target GetCurrentTarget(LayerMask layerMask)
    {
        (int aggro, AggroTrigger trigger) highestAggroTrigger = GetHighestAggroTrigger(layerMask);
        if (highestAggroTrigger.trigger)
        {
            return new Target(highestAggroTrigger.trigger.transform);
        }

        return new Target(Vector3.zero);
    }
}
