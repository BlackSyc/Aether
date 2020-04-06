using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AggroTable : MonoBehaviour
{
    [SerializeField]
    private LayerMask contentMask;

    [SerializeField]
    private float aggroRange;

    public LayerMask LayerMask => contentMask;

    private List<(int aggro, AggroTrigger trigger)> aggroTriggers = new List<(int, AggroTrigger)>();

    public bool Contains(AggroTrigger trigger)
    {
        return aggroTriggers.Any(x => x.trigger == trigger);
    }

    public AggroTrigger GetHighestAggroTrigger()
    {
        return aggroTriggers
            .Single(x => x.aggro == aggroTriggers
                .Max(y => y.aggro)).trigger;
    }

    public void AddAggroTrigger(AggroTrigger aggroTrigger)
    {
        if (!contentMask.Contains(aggroTrigger.gameObject))
            return;

        if (Contains(aggroTrigger))
            return;

        aggroTriggers.Add((aggroTrigger.Bias, aggroTrigger));
        aggroTrigger.GlobalAggroRaised += x => IncreaseAggro(aggroTrigger, x);

        Debug.Log($"{aggroTrigger.gameObject.name} added to {gameObject.name}'s aggro table with a bias of {aggroTrigger.Bias}");
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
        LookForNewTriggers();
    }

    private void LookForNewTriggers()
    {
        Physics.OverlapSphere(transform.position, aggroRange, contentMask)
            .Select(x => x.GetComponent<AggroTrigger>())
            .Where(x => x != null)
            .Where(x => !Contains(x))
            .ForEach(x => AddAggroTrigger(x));
    }
}
