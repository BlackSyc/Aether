using System.Collections;
using Aether.Core;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField]
        private Transform respawnLocation;

        [SerializeField] private float scaleSpeed = 1f;
    
        private bool _isRespawning;
    
    

        // Update is called once per frame
        void Update()
        {
            if (_isRespawning)
                return;
        
            if (Player.Instance.transform.position.y < -100f)
            {
                _isRespawning = true;
                StartCoroutine(RespawnCoroutine());
            }
        }

        private IEnumerator RespawnCoroutine()
        {
            
        
            Player.Instance.GetComponent<CharacterController>().enabled = false;
            yield return null;
            Player.Instance.transform.position = respawnLocation.position;
            yield return null;
            Player.Instance.GetComponent<CharacterController>().enabled = true;
            

            _isRespawning = false;
        }
    
    }
}
