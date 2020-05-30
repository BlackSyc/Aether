using UnityEngine;

namespace Aether.Core.SceneManagement
{
    public interface ILevelController
    {
        Transform GetEntryPoint();

        LevelExit GetLevelExit();

        void Enable();

        void Disable();
    }
}
