﻿using UnityEngine;

namespace Aether.Core.Combat
{
    public interface ISpell
    {
        LayerMask LayerMask { get; }

        bool CastWhileMoving { get; }

        bool RequiresCombatTarget { get; }

        float CastDuration { get; }

        int GlobalAggro { get; }

        int LocalAggro { get; }

        float CoolDown { get; }

        string Name { get; }

        float HealthDelta { get; }

        string Description { get; }

        bool OnlyCastOnSelf { get; }
        bool OnGlobalCooldown { get; }

        void Initialize(ISpellCast spellCast);
    }
}
