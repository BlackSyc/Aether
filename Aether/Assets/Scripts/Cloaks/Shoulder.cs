using Aether.Combat;
using Aether.Core.Cloaks;
using Aether.Core.Cloaks.ScriptableObjects;
using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Cloaks
{
    public class Shoulder : MonoBehaviour, IShoulder
    {
        public CombatSystem CombatSystem;

        public Cloak EquippedCloak { get; private set; } = null;

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

        public void EquipCloak(Cloak cloak)
        {
            if (EquippedCloak != null)
                UnequipCloak();

            EquippedCloak = cloak;
            cloak.Equip(transform);
        }

        public void UnequipCloak()
        {
            var cloak = EquippedCloak;
            EquippedCloak = null;
            cloak?.Unequip();
            CombatSystem.Get<ISpellSystem>().AddSpell(0, defaultSpell);
        }
    }
}
