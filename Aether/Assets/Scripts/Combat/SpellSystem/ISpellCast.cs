using Aether.Core.Combat;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellCast : Core.Combat.ISpellCast
    {
        #region Public Properties

        new Target Target { get; }

        float Progress { get; }

        new ISpell Spell { get; }

        bool CastOnSelf { get; }
        #endregion


        void UpdateTarget(Target newTarget);

        void Cancel();

        void Interrupt();

        void Update();

        void Start();
    }
}
