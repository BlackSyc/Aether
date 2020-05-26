using UnityEngine;

namespace Aether.Core.SceneManagement
{
    public class StartPlatformController : MonoBehaviour, ILevelController
    {
        [SerializeField]
        private bool DisableOnStart = true;
        // Start is called before the first frame update
        void Start()
        {
            SceneController.Instance.StartPlatformLevelController = this;


            if (DisableOnStart)
            {
                Disable();
            }
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public Transform GetEntryPoint()
        {
            return null;
        }

        public LevelExit GetLevelExit()
        {
            return null;
        }
    }
}
