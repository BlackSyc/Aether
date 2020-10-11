using Aether.Core.Cloaks;
using System;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
using Syc.Core.System;
using UnityEngine;

namespace Aether.Cloaks
{
    public class Shoulder : MonoSubSystem, IShoulder
    {
        [SerializeField]
        private CombatMonoSystem combatSystem;
        public ICloak EquippedCloak { get; private set; } = null;

        private GameObject equippedCloakObject;

        [SerializeField]
        private Spell defaultSpell;

        public event Action<ICloak> OnCloakChanged;

        public void EnableCloakPhysics()
        {
            if (transform.GetChild(0) == null)
                return;

            transform.GetChild(0).GetComponent<Cloth>().enabled = true;
        }

        public void DisableCloakPhysics()
        {
            if (transform.GetChild(0) == null)
                return;

            transform.GetChild(0).GetComponent<Cloth>().enabled = false;
        }

        public void EquipCloak(ICloak cloak)
        {
            if (EquippedCloak != null)
                UnequipCloak();

            equippedCloakObject = Instantiate(cloak.CloakPrefab, transform);
            equippedCloakObject.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };

            if (cloak.Spells != null && combatSystem.Has(out SpellRack spellRack))
            {
                spellRack.RemoveAllSpells();
                for (var i = 0; i < cloak.Spells.Length; i++)
                {
                    spellRack.AddSpell(cloak.Spells[i], i);
                }
            }

            EquippedCloak = cloak;
            OnCloakChanged?.Invoke(cloak);
        }

        public void UnequipCloak()
        {
            var cloak = EquippedCloak;
            EquippedCloak = null;

            Destroy(equippedCloakObject);

            if (combatSystem.Has(out SpellRack spellRack))
            {
                spellRack.RemoveAllSpells();
                
                if(defaultSpell != null)
                    spellRack.AddSpell(defaultSpell, 0);
            }

            OnCloakChanged?.Invoke(null);
        }
    }
}
