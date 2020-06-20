using Aether.Core.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    internal class ModifierSlots : MonoBehaviour, Core.Combat.IModifierSlots
    {
        public event Action<Core.Combat.IModifierType> OnModifierAdded;

        public event Action<Core.Combat.IModifierType> OnModifierRemoved;

        private List<IModifierType> activeModifiers;
        public ICombatSystem CombatSystem { get; set; }

        private void Start()
        {
            CombatSystem = GetComponent<ICombatSystem>();
            activeModifiers = new List<IModifierType>();
        }

        public void AddModifier(IModifierType modifierType)
        {
            var sameModifier = activeModifiers.SingleOrDefault(x => x.ModifierType == modifierType);
            if (sameModifier != null)
            {
                sameModifier.FallOffTime = Time.time + modifierType.Duration;
                return;
            }

            Modifier modifier = new Modifier(modifierType);
            activeModifiers.Add(modifier);
            modifier.Coroutine = StartCoroutine(modifier.ModifierCoroutine(CombatSystem));
            OnModifierAdded?.Invoke(modifier);
        }

        public void RemoveModifier(IModifierType modifier)
        {
            activeModifiers.Remove(modifier);

            modifier.Abort(CombatSystem);
            StopCoroutine(modifier.Coroutine);
            OnModifierRemoved?.Invoke(modifier);
        }

        private void Update()
        {
            activeModifiers.RemoveAll(x =>
            {
                if (x.FallOffTime < Time.time)
                {
                    x.Abort(CombatSystem);

                    if (x.Coroutine != null)
                        StopCoroutine(x.Coroutine);

                    OnModifierRemoved?.Invoke(x);
                    return true;
                }
                return false;
            });
        }
    }
}
