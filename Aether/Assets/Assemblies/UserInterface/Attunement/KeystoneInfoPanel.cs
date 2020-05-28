using Aether.Core.Attunement;
using Aether.Core.Items.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Attunement
{
    public class KeystoneInfoPanel : MonoBehaviour
    {
        #region Private Fields
        private Keystone currentKeystone;

        private IAttunementDevice attunementDevice;
        #endregion

        #region Serialized Fields
        [SerializeField]
        private Image keystoneSprite;

        [SerializeField]
        private TextMeshProUGUI keystoneNameText;

        [SerializeField]
        private TextMeshProUGUI keystoneDescriptionText;

        [SerializeField]
        private Button activateButton;

        [SerializeField]
        private TextMeshProUGUI activateButtonText;

        [SerializeField]
        private RectTransform keystoneLabelParent;

        [SerializeField]
        private GameObject keystoneLabelPrefab;
        #endregion

        #region Public Methods
        public void Show(Keystone keystone, IAttunementDevice attunementDevice)
        {
            CleanPanel();

            this.currentKeystone = keystone;

            keystoneNameText.text = this.currentKeystone.Name;

            this.currentKeystone.Labels.ForEach(x =>
            {
                GameObject label = GameObject.Instantiate(keystoneLabelPrefab, keystoneLabelParent);
                label.GetComponent<KeystoneLabel>().SetText(x);
            });

            keystoneDescriptionText.text = this.currentKeystone.Description;

            keystoneSprite.sprite = this.currentKeystone.Sprite ? this.currentKeystone.Sprite : null;

            activateButton.onClick.AddListener(() => attunementDevice.Toggle(keystone));
            activateButtonText.text = this.currentKeystone.IsActivated ? "Deactivate" : "Activate";
        }
        #endregion

        #region MonoBehaviour
        private void Start()
        {
            KeystoneEvents.OnKeystoneActivated += UpdateButtonLabel;
            KeystoneEvents.OnKeystoneDeactivated += UpdateButtonLabel;
        }

        private void OnDestroy()
        {
            KeystoneEvents.OnKeystoneActivated -= UpdateButtonLabel;
            KeystoneEvents.OnKeystoneDeactivated -= UpdateButtonLabel;
        }

        #endregion

        #region EventHandlers
        private void UpdateButtonLabel(Keystone keystone)
        {
            if (keystone != currentKeystone)
                return;

            activateButtonText.text = currentKeystone.IsActivated ? "Deactivate" : "Activate";
        }
        #endregion

        #region Private Methods
        private void CleanPanel()
        {
            foreach (Transform label in keystoneLabelParent)
            {
                Destroy(label.gameObject);
            }

            activateButton.onClick.RemoveAllListeners();
        }
        #endregion
    }
}
