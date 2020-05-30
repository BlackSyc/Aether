using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    internal class ModifierSlots : MonoBehaviour, IModifierSlots, Core.Combat.IModifierSlots
    {
        public event Action<Core.Combat.IModifier> OnModifierAdded;

        public event Action<Core.Combat.IModifier> OnModifierRemoved;

        private List<IModifier> activeModifiers;
        public ICombatSystem CombatSystem { get; set; }

        private void Start()
        {
            activeModifiers = new List<IModifier>();
        }

        public void AddModifier(IModifier modifier)
        {
            var sameModifier = activeModifiers.SingleOrDefault(x => x.ModifierType == modifier.ModifierType);
            if (sameModifier != null)
            {
                sameModifier.FallOffTime = Time.time + sameModifier.ModifierType.Duration;
                return;
            }


            activeModifiers.Add(modifier);
            modifier.Coroutine = StartCoroutine(modifier.ModifierCoroutine(CombatSystem));
            OnModifierAdded?.Invoke(modifier);
        }

        public void RemoveModifier(IModifier modifier)
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
