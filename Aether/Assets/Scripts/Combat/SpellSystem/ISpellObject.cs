using Aether.Core.Combat;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellObject : Core.Combat.ISpellObject
    {
        ISpell Spell { get; set; }

        Core.Combat.ICombatSystem Caster { get; set; }

        Core.Combat.ICombatSystem Target { get; }

        void SetTarget(Core.Combat.ICombatSystem newTarget);

        void CastStarted();

        void CastInterrupted();

        void CastCanceled();

        void CastFired();
    }
}
