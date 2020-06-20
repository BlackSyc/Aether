using Aether.Core.Combat;
using Aether.ScriptableObjects.Modifiers;
using System;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spell System/Modifier Spell")]
    [Serializable]
    public class ModifierSpell : SpellBase
    {
        [SerializeField]
        private ModifierBase modifier;

        public override void Initialize(ISpellCast spellCast)
        {
            modifier.Initialize(spellCast);
        }
    }
}
