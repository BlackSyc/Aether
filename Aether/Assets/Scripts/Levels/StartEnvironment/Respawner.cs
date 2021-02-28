using System;
using System.Collections;
using Aether.Core;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
    public class Respawner : MonoBehaviour, ILocalPlayerLink
    {
        [SerializeField]
        private Transform respawnLocation;

        private Player _player;

        private void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!_player)
            {
                return;
            }
            
            if (_player.transform.position.y < -100f)
            {
                StartCoroutine(RespawnRoutine());
            }
        }

        private IEnumerator RespawnRoutine()
        {
            _player.GetComponent<CharacterController>().detectCollisions = false;
            _player.transform.position = respawnLocation.position;
            yield return new WaitForFixedUpdate();
            _player.GetComponent<CharacterController>().detectCollisions = true;
        }

        public void OnLocalPlayerLinked(Player player)
        {
            _player = player;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            _player = null;
        }
    }
}
