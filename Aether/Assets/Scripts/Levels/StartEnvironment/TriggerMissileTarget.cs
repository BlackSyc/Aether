using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
using Syc.Combat.SpellSystem.ScriptableObjects.SpellEffects;
using Syc.Combat.TargetSystem;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
    [CreateAssetMenu(menuName = "Aether/Spell System/Spells/Effects/Trigger Missile Target")]
    public class TriggerMissileTarget : SpellEffect
    {
        public override void Execute(ICaster source, Target target, Spell spell, SpellCast spellCast = default,
            SpellObject spellObject = default)
        {
            var combatSystem = target.CombatSystem;
            if (combatSystem == null)
                return;

            if (!combatSystem.Has(out Puzzle1MissileTarget missileTarget))
                return;
            
            missileTarget.Hit();
        }
    }
}
