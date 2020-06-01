using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Combat;
using Aether.Core.Interaction;
using Aether.ScriptableObjects.Cloaks;
using UnityEngine;

namespace Aether.Cloaks
{
    [RequireComponent(typeof(IInteractable))]
    internal class CloakProvider : MonoBehaviour, ICloakProvider
    {
        
        [SerializeField]
        private GameObject cloakObject;

        [SerializeField]
        private Cloak cloak;

        private IInteractable _interactable;

        public ICloak Cloak => cloak;

        public void Equip()
        {
            Player.Instance.Get<IShoulder>().EquipCloak(cloak);
            CheckEquip(cloak);
        }

        public void Unequip()
        {
            Player.Instance.Get<IShoulder>().UnequipCloak();
            CheckEquip(cloak);
        }

        private void Awake()
        {
            _interactable = GetComponent<IInteractable>();
        }

        private void Start()
        {
            Core.Cloaks.Events.OnCloakEquipped += CheckEquip;
            Core.Cloaks.Events.OnCloakUnequipped += CheckEquip;
        }

        private void CheckEquip(ICloak cloak)
        {
            if (cloak != Cloak)
                return;

            var playerEquipped = Player.Instance.Get<IShoulder>().EquippedCloak;
            cloakObject.SetActive(playerEquipped == cloak);
        }

        private void OnDestroy()
        {
            Core.Cloaks.Events.OnCloakEquipped -= CheckEquip;
            Core.Cloaks.Events.OnCloakUnequipped -= CheckEquip;
        }
    }
}
