using Aether.Core.Attunement;
using Aether.Core.Extensions;
using Aether.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Aether.UserInterface.Attunement
{
    public class AttunementWindow : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField]
        private GameObject attunementWindow;

        [SerializeField]
        private RectTransform keystoneSelectorParent;

        [SerializeField]
        private ScrollRect keystoneSelectorScrollRect;

        [SerializeField]
        private GameObject keystoneSelectorPrefab;

        [SerializeField]
        private KeystoneInfoPanel keystoneInfoPanel;
        #endregion

        #region MonoBehaviour
        void Start()
        {
            Events.OnInteract += OpenWindow;
        }

        private void OnDestroy()
        {
            Events.OnInteract -= OpenWindow;
        }
        #endregion

        #region EventHandlers
        private void OpenWindow(IAttunementDevice attunementDevice)
        {
            attunementWindow.SetActive(true);

            bool selectionMade = false;

            attunementDevice.Keystones.ForEach(keystone =>
            {
                GameObject keystoneSelectorObject = GameObject.Instantiate(keystoneSelectorPrefab, keystoneSelectorParent);
                KeystoneSelector keystoneSelector = keystoneSelectorObject.GetComponent<KeystoneSelector>();
                keystoneSelector.SetKeystone(keystone);
                keystoneSelector.OnSelect = () => keystoneInfoPanel.Show(keystone, attunementDevice);
                keystoneSelector.OnScroll = Scroll;

                if (!selectionMade)
                {
                    selectionMade = true;
                    keystoneSelector.Select();
                }
            });

            attunementDevice.NewKeystones.ForEach(newKeystone =>
            {
                GameObject keystoneSelectorObject = GameObject.Instantiate(keystoneSelectorPrefab, keystoneSelectorParent);
                KeystoneSelector keystoneSelector = keystoneSelectorObject.GetComponent<KeystoneSelector>();
                keystoneSelector.SetKeystone(newKeystone);
                keystoneSelector.OnSelect = () => keystoneInfoPanel.Show(newKeystone, attunementDevice);
                keystoneSelector.OnScroll = Scroll;
                keystoneSelector.PlayNewlyAddedAnimation();

                if (!selectionMade)
                {
                    selectionMade = true;
                    keystoneSelector.Select();
                }
            });

            attunementDevice.ApplyNewKeystones();

            InputSystem.SwitchToActionMap(ActionMap.PopUp);

        }

        private void CloseWindow()
        {
            if (attunementWindow.activeSelf)
            {
                attunementWindow.SetActive(false);

                foreach (Transform child in keystoneSelectorParent)
                {
                    Destroy(child.gameObject);
                }

                InputSystem.SwitchToActionMap(ActionMap.Player);
            }
        }
        #endregion

        #region Private Methods
        private void Scroll(PointerEventData pointerEventData)
        {
            keystoneSelectorScrollRect.OnScroll(pointerEventData);
        }
        #endregion
    }
}
