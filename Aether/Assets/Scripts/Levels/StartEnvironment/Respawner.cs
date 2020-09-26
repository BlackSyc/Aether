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
            while (transform.localScale.magnitude > 0)
            {
                var scaleAmount = Time.deltaTime * scaleSpeed;
                var currentScale = transform.localScale;
                var newScaleX = currentScale.x - scaleAmount < 0
                    ? 0
                    : currentScale.x - scaleAmount;
                var newScaleY = currentScale.y - scaleAmount < 0
                    ? 0
                    : currentScale.y - scaleAmount;
                var newScaleZ = currentScale.z - scaleAmount < 0
                    ? 0
                    : currentScale.z - scaleAmount;
            
                transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
            
                yield return null;
            }
        
            Player.Instance.GetComponent<CharacterController>().enabled = false;
            yield return null;
            Player.Instance.transform.position = respawnLocation.position;
            yield return null;
            Player.Instance.GetComponent<CharacterController>().enabled = true;
        
            while (transform.localScale.magnitude < 1)
            {
                var scaleAmount = Time.deltaTime * scaleSpeed;
                var currentScale = transform.localScale;
                var newScaleX = currentScale.x + scaleAmount > 1
                    ? 1
                    : currentScale.x + scaleAmount;
                var newScaleY = currentScale.y + scaleAmount > 1
                    ? 1
                    : currentScale.y + scaleAmount;
                var newScaleZ = currentScale.z + scaleAmount > 1
                    ? 1
                    : currentScale.z + scaleAmount;
            
                transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
            
                yield return null;
            }

            _isRespawning = false;
        }
    
    }
}
