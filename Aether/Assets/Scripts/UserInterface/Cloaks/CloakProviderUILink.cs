using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.UserInterface;
using Aether.Input;
using UnityEngine;

namespace Aether.UserInterface.Cloaks
{
    [RequireComponent(typeof(ICloakProvider))]
    public class CloakProviderUILink : MonoBehaviour
    {
        [SerializeField]
        private CloakWindow cloakWindowPrefab;

        [SerializeField]
        private UIContainer uiContainer;

        private CloakWindow _activeCloakWindow;

        public ICloakProvider CloakProvider { get; private set; }

        private void Awake()
        {
            CloakProvider = GetComponent<ICloakProvider>();    
        }

        public void OpenWindow()
        {
            RectTransform windowParent = Player.Instance.Get<IUserInterface>().GetContainer(uiContainer);

            if (windowParent == null)
                return;

            _activeCloakWindow = Instantiate(cloakWindowPrefab, windowParent).GetComponent<CloakWindow>()
                .Link(this)
                .Build();

            InputSystem.SwitchToActionMap(ActionMap.PopUp);
        }

        public void CloseWindow()
        {
            Destroy(_activeCloakWindow.gameObject);
            _activeCloakWindow = null;
            InputSystem.SwitchToActionMap(ActionMap.Player);
        }


    }
}
