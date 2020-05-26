using Aether.Input;
using UnityEngine;

namespace Aether.UserInterface.Tutorial
{
    public class HintCloseButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            InputSystem.OnActionMapSwitched += ActionMapSwapped;
            gameObject.SetActive(false);
        }

        private void ActionMapSwapped(ActionMap newActionMap)
        {
            if (newActionMap.Equals(ActionMap.UserInterface))
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            InputSystem.OnActionMapSwitched -= ActionMapSwapped;
        }
    }
}
