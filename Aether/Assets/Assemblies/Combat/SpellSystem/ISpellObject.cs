using Aether.Core.Combat.ScriptableObjects;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellObject : Core.Combat.ISpellObject
    {
        Spell Spell { get; set; }

        ISpellSystem Caster { get; set; }

        ICombatSystem Target { get; }

        void SetTarget(ICombatSystem newTarget);

        void CastStarted();

        void CastInterrupted();

        void CastCanceled();

        void CastFired();
    }
}
