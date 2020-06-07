using System;

namespace Aether.Core.Combat
{
    public interface ISpellCast
    {
        event Action<ISpellCast> CastStarted;
        event Action<float> CastProgress;
        event Action<ISpellCast> CastCancelled;
        event Action<ISpellCast> CastInterrupted;
        event Action<ISpellCast> CastComplete;

        Target Target { get; }
        ISpell Spell { get; }
    }
}
