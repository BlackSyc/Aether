using Aether.Assets.Assemblies.Core.Items;
using Aether.Core;
using Aether.Core.Items.ScriptableObjects;
using Aether.Core.Tutorial;
using UnityEngine;

namespace Aether.Attunement
{
    public class KeystoneObject : MonoBehaviour
    {
        [SerializeField]
        private Keystone keystone;

        public void PickUp()
        {
            if (keystone.IsFound)
            {
                Hints.Get("Keystone_AlreadyPickedUp").Activate();
                return;
            }
            Player.Instance.Get<IInventory>().PickupKeystone(keystone);
            Destroy(gameObject);
        }
    }
}
