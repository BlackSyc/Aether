﻿using System;
using System.Collections;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    [Serializable]
    public abstract class ModifierType : ScriptableObject
    {
        public string Name;

        public float Duration;

        public string Description;

        public Sprite Icon;

        public abstract IEnumerator modifierCoroutine(ICombatSystem combatSystem);

        public virtual void Stop(ICombatSystem combatSystem) { }
    }
}
