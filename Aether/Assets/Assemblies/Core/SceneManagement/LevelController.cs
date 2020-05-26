using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether.Core.SceneManagement
{
    public class LevelController : MonoBehaviour, ILevelController
    {

        [SerializeField]
        private bool DisableOnStart = true;

        [SerializeField]
        private Transform entryPoint;

        [SerializeField]
        private LevelExit levelExit;

        protected virtual void Start()
        {
            if (gameObject.scene.buildIndex.Equals(SceneController.Instance.LoadedLevel.buildIndex))
            {
                SceneController.Instance.LoadedLevel.levelController = this;
            }

            if (DisableOnStart)
            {
                Disable();
            }
        }

        public virtual void Enable()
        {
            gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            gameObject.SetActive(false);
        }

        public Transform GetEntryPoint()
        {
            return entryPoint;
        }

        public LevelExit GetLevelExit()
        {
            return levelExit;
        }
    }
}

