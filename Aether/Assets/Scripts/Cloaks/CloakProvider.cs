using Aether.Core;
using Aether.Core.Cloaks;
using Aether.ScriptableObjects.Cloaks;
using Syc.Core.Interaction;
using UnityEngine;

namespace Aether.Cloaks
{
    [RequireComponent(typeof(Interactable))]
    internal class CloakProvider : MonoBehaviour, ICloakProvider
    {

        [SerializeField]
        private GameObject cloakObject;

        [SerializeField]
        private Cloak cloak;

        public ICloak Cloak => cloak;

        public void Equip(Interactor interactor)
        {
            if (interactor.Has(out IShoulder shoulder))
                shoulder.EquipCloak(cloak);
        }

        public void Unequip(Interactor interactor)
        {
            if (interactor.Has(out IShoulder shoulder))
                shoulder.UnequipCloak();
        }

        private void Start()
        {
            if(Player.Instance.Has(out IShoulder shoulder))
                shoulder.OnCloakChanged += CheckEquip;
        }

        private void CheckEquip(ICloak playerEquippedCloak)
        {
            cloakObject.SetActive(playerEquippedCloak != Cloak);
        }

        private void OnDestroy()
        {
            if(Player.Instance.Has(out IShoulder shoulder))
                shoulder.OnCloakChanged += CheckEquip;
        }
    }
}
