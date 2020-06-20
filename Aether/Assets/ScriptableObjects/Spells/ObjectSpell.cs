using Aether.Core.Combat;
using Aether.ScriptableObjects.Spells.Behaviours;
using System;
using UnityEngine;


namespace Aether.ScriptableObjects.Spells
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Object Spell")]
    [Serializable]
    public class ObjectSpell : SpellBase
    {
        [SerializeField]
        private SpellBehaviour spellPrefab;

        public override void Initialize(ISpellCast spellCast)
        {
            SpellBehaviour spellBehaviour = Instantiate(spellPrefab, spellCast.CastOrigin).GetComponent<SpellBehaviour>();
            spellBehaviour.Link(spellCast);
        }
    }
}
