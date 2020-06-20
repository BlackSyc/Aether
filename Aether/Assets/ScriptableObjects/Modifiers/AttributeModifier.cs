using Aether.Core.Combat;
using UnityEngine;

namespace Aether.ScriptableObjects.Modifiers
{
    public class AttributeModifier : ModifierBase
    {
        [SerializeField]
        private AttributeModifierBehaviour prefab;

        public override void Initialize(ISpellCast spellCast)
        {
            AttributeModifierBehaviour modBehaviour = Instantiate(prefab, spellCast.CastOrigin).GetComponent<AttributeModifierBehaviour>();
            modBehaviour.Link(spellCast);
        }
    }
}
