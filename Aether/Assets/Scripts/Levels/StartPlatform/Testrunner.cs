using System;
using System.Collections;
using UnityEngine;

namespace Aether.StartPlatform
{
    public class Testrunner : MonoBehaviour
    {
        [SerializeField]
        private bool spawnCloaks;

        private void Start()
        {
            if (spawnCloaks)
                InvokeNextFrame(SpawnCloaks);
        }

        [ContextMenu("Spawn Cloaks")]
        private void SpawnCloaks()
        {
            Puzzle1_Manager.Events.Stage2Completed();
        }

        #region Invokers
        private void InvokeNextFrame(Action action)
        {
            StartCoroutine(ExecuteNextFrame(action));
        }

        private IEnumerator ExecuteNextFrame(Action action)
        {
            yield return null;
            action.Invoke();
        }
        #endregion
    }
}
