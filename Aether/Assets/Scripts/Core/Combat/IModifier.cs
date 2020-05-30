using System.Collections;
using UnityEngine;

namespace Aether.Core.Combat
{
    public interface IModifier
    {
        IModifierType ModifierType { get; }

        float FallOffTime { get; set; }

        Coroutine Coroutine { get; set; }

        IEnumerator ModifierCoroutine(ICombatSystem combatSystem);

        void Abort(ICombatSystem combatSystem);
    }
}
