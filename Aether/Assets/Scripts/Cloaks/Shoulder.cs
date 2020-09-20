using Aether.Core.Cloaks;
using System;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
using UnityEngine;

namespace Aether.Cloaks
{
    public class Shoulder : MonoBehaviour, IShoulder
    {
        [SerializeField]
        private CombatMonoSystem combatSystem;
        public ICloak EquippedCloak { get; private set; } = null;

        private GameObject equippedCloakObject;

        [SerializeField]
        private SpellBehaviour defaultSpell;

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

            if (cloak.Spells != null)
            {
                for (var i = 0; i < cloak.Spells.Length; i++)
                {
                    var castingSystem = combatSystem.Get<SpellRack>();
                    castingSystem.AddSpell(cloak.Spells[i], i);
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

            combatSystem.Get<SpellRack>().RemoveAllSpells();
            combatSystem.Get<SpellRack>().AddSpell(defaultSpell, 0);

            OnCloakChanged?.Invoke(null);
        }
    }
}
