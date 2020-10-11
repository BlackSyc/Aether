using System;
using Aether.UserInterface.Cloaks;
using Syc.Core.Interaction;
using UnityEngine;

namespace Aether.UserInterface
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private CloakWindow cloakWindowPrefab;

        private CloakWindow _activeCloakWindow;
        public static WindowManager Instance { get; private set; }
        
        // Start is called before the first frame update
        private void Awake()
        {
            if (Instance)
                throw new Exception("There is more than one WindowManager object in the game!");

            Instance = this;
        }

        public void ShowCloakWindowFor(CloakProviderUILink cloakProviderUILink, Interactor interactor)
        {
            if (_activeCloakWindow != null)
                return;
            
            _activeCloakWindow = Instantiate(cloakWindowPrefab, transform)
                .Link(cloakProviderUILink)
                .Build(interactor);
        }

        public void HideCloakWindow()
        {
            if (_activeCloakWindow == null)
                return;
            
            Destroy(_activeCloakWindow.gameObject);
            _activeCloakWindow = null;
        }
    }
}
