using Aether.Core.Cloaks;
using Aether.Input;
using Syc.Core.Interaction;
using UnityEngine;

namespace Aether.UserInterface.Cloaks
{
    [RequireComponent(typeof(ICloakProvider))]
    public class CloakProviderUILink : MonoBehaviour
    {
        public ICloakProvider CloakProvider { get; private set; }

        private void Awake()
        {
            CloakProvider = GetComponent<ICloakProvider>();
        }

        public void OpenWindow(Interactor interactor, Interactable _)
        {
            WindowManager.Instance.ShowCloakWindowFor(this, interactor);

            InputSystem.SwitchToActionMap(ActionMap.PopUp);
        }

        public void CloseWindow()
        {
            WindowManager.Instance.HideCloakWindow();
            InputSystem.SwitchToActionMap(ActionMap.Player);
        }
    }
}
