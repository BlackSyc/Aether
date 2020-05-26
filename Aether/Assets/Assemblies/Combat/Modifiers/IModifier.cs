using Aether.Core.Combat.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    internal interface IModifier : Core.Combat.IModifier
    {
        ModifierType ModifierType { get; }

        float FallOffTime { get; set; }

        Coroutine Coroutine { get; set; }

        IEnumerator ModifierCoroutine(ICombatSystem combatSystem);

        void Abort(ICombatSystem combatSystem);
    }
}
