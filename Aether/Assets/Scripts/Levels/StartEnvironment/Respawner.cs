using System.Collections;
using Aether.Core;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField]
        private Transform respawnLocation;

    
    

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Player.Instance.transform.position.y < -100f)
            {
                StartCoroutine(RespawnRoutine());
            }
        }

        private IEnumerator RespawnRoutine()
        {
            Player.Instance.GetComponent<CharacterController>().detectCollisions = false;
            Player.Instance.transform.position = respawnLocation.position;
            yield return new WaitForFixedUpdate();
            Player.Instance.GetComponent<CharacterController>().detectCollisions = true;
        }
    
    }
}
