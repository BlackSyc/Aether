using System.Collections;
using UnityEngine;

namespace Aether.Core.Combat
{
    public interface IModifierType
    {
        string Name { get; }

        float Duration { get; }

        string Description { get; }

        Sprite Icon { get; }

        IEnumerator ModifierCoroutine(ICombatSystem combatSystem);

        void Abort(ICombatSystem combatSystem);
    }
}
