using Aether.Core;
using Aether.Core.Cloaks;
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

        public ICloak Cloak => cloak;

        public void Equip(IInteractor interactor)
        {
            if (interactor.Has(out IShoulder shoulder))
                shoulder.EquipCloak(cloak);
        }

        public void Unequip(IInteractor interactor)
        {
            if (interactor.Has(out IShoulder shoulder))
                shoulder.UnequipCloak();
        }

        private void Start()
        {
            Player.Instance.Get<IShoulder>().OnCloakChanged += CheckEquip;
        }

        private void CheckEquip(ICloak playerEquippedCloak)
        {
            cloakObject.SetActive(playerEquippedCloak != Cloak);
        }

        private void OnDestroy()
        {
            Player.Instance.Get<IShoulder>().OnCloakChanged += CheckEquip;
        }
    }
}
