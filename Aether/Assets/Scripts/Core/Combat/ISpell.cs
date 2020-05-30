using System;
using UnityEngine;

namespace Aether.Core.Combat
{
    public interface ISpell
    {
        LayerMask LayerMask { get; }

        bool CastWhileMoving { get; }

        float CastDuration { get; }

        ISpellObject SpellObject { get; }

        int GlobalAggro { get; }

        float CoolDown { get; }

        string Name { get; }

        float HealthDelta { get; }

        string Description { get; }

        bool OnlyCastOnSelf { get; }
    }
}
