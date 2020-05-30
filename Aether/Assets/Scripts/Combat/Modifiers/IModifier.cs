using Aether.Core.Combat;
using System.Collections;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    internal interface IModifier : Core.Combat.IModifier
    {
        new IModifierType ModifierType { get; }

        new float FallOffTime { get; set; }

        Coroutine Coroutine { get; set; }

        IEnumerator ModifierCoroutine(ICombatSystem combatSystem);

        void Abort(ICombatSystem combatSystem);
    }
}
