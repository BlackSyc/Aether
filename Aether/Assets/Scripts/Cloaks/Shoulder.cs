using Aether.Combat;
using Aether.Core.Cloaks;
using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Cloaks
{
    public class Shoulder : MonoBehaviour, IShoulder
    {
        public CombatSystem CombatSystem;

        public ICloak EquippedCloak { get; private set; } = null;

        private GameObject equippedCloakObject;

        [SerializeField]
        private ISpell defaultSpell;

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
                for (int i = 0; i < cloak.Spells.Length; i++)
                {
                    ISpellSystem spellSystem = CombatSystem.Get<ISpellSystem>();
                    spellSystem.AddSpell(i, cloak.Spells[i]);
                    CombatSystem.Get<ISpellSystem>()?.AddSpell(i, cloak.Spells[i]);
                }
            }

            
            EquippedCloak = cloak;
            Events.CloakEquipped(cloak);
        }

        public void UnequipCloak()
        {
            var cloak = EquippedCloak;
            EquippedCloak = null;
            CombatSystem.Get<ISpellSystem>().AddSpell(0, defaultSpell);

            Events.CloakUnequipped(cloak);
        }
    }
}
