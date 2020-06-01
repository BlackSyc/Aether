using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Cloaks.ScriptableObjects;
using Aether.Core.Interaction;
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

        public Cloak Cloak => cloak;

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

        private void CheckEquip(Cloak cloak)
        {
            if (cloak != Cloak)
                return;

            cloakObject.SetActive(Cloak.IsEquipped);
            _interactable.IsActive = Cloak.IsEquipped;
        }

        private void OnDestroy()
        {
            Core.Cloaks.Events.OnCloakEquipped -= CheckEquip;
            Core.Cloaks.Events.OnCloakUnequipped -= CheckEquip;
        }
    }
}
