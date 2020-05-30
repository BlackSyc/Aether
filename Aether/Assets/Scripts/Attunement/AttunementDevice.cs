using Aether.Assets.Assemblies.Core.Items;
using Aether.Core.Attunement;
using Aether.Core.Interaction;
using Aether.Core.Items.ScriptableObjects;
using Aether.Core.SceneManagement;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Aether.Attunement
{
    public class AttunementDevice : MonoBehaviour, IAttunementDevice
    {
        #region Private Fields

        private Keystone _activeKeystone = null;

        #endregion

        #region Serialized Fields

        [SerializeField]
        private List<Keystone> keystones;

        private List<Keystone> newKeystones = new List<Keystone>();

        [SerializeField]
        private Aspect aspect;

        [SerializeField]
        private TravellerPlatform _travellerPlatform;

        [SerializeField]
        private Traveller _traveller;

        [SerializeField]
        private GameObject keystoneObject;

        #endregion

        #region Getters
        public ReadOnlyCollection<Keystone> Keystones => keystones.AsReadOnly();

        public ReadOnlyCollection<Keystone> NewKeystones => newKeystones.AsReadOnly();
        #endregion

        #region Public Methods
        public void ApplyNewKeystones()
        {
            keystones.AddRange(newKeystones);
            newKeystones.Clear();
        }

        public void Toggle(Keystone keystone)
        {
            if (keystone == null)
                return;

            if (keystone.IsActivated)
                Deactivate(keystone);
            else
                Activate(keystone);
        }

        // Interaction Handler
        public void Interact(IInteractor interactor, IInteractable _)
        {
            IInventory interactorInventory = interactor.Get<IInventory>();

            if (interactorInventory != null)
            {
                newKeystones.AddRange(interactorInventory.ExtractKeystones(x => x.Aspect == aspect));
            }

            Core.Attunement.Events.Interact(this);
        }

        public void PrepareForInteraction(IInteractor interactor, IInteractable interactable)
        {
            if (interactable != GetComponent<IInteractable>())
                return;

            if (interactor.Get<IInventory>().Keystones.Count > 0)
            {
                interactable.InteractionMessage = "to place keystones";
            }
            else
            {
                interactable.InteractionMessage = "to activate a keystone";
            }
        }

        #endregion

        #region Private Methods

        private void Activate(Keystone keystone)
        {
            if (_activeKeystone != keystone)
            {
                if (_activeKeystone != null)
                    Deactivate(_activeKeystone);

                _travellerPlatform.gameObject.SetActive(true);
                _traveller.gameObject.SetActive(true);
                _activeKeystone = keystone;
                _travellerPlatform.Traveller.TravelAnimation = _activeKeystone.TravelAnimation;
                _travellerPlatform.Traveller.SceneBuildIndex = _activeKeystone.SceneBuildIndex;

            }

            keystoneObject.SetActive(true);
            _activeKeystone.Activate();
        }

        private void Deactivate(Keystone keystone)
        {
            _travellerPlatform.gameObject.SetActive(false);
            _traveller.gameObject.SetActive(false);
            _travellerPlatform.Traveller.TravelAnimation = null;

            _activeKeystone = null;
            keystoneObject.SetActive(false);
            keystone.Deactivate();

            SceneController.Instance.UnloadLevel(keystone.SceneBuildIndex);
        }

        #endregion
    }
}
