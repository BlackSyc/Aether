using Aether.Core;
using Aether.Core.Companion;
using Aether.Core.Items.ScriptableObjects;
using UnityEngine;

namespace Aether.Cloaks
{
    public class DreamCloak : MonoBehaviour, ILocalPlayerLink
    {
        [SerializeField]
        private GameObject robinPrefab;

        [SerializeField]
        private Keystone spawnRobinIfFound;

        private void Start()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public void OnLocalPlayerLinked(Player player)
        {
            if (spawnRobinIfFound.IsFound && player.Has<ICompanion>())
            {
                Instantiate(robinPrefab, player.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
            }
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
        }
    }
}
