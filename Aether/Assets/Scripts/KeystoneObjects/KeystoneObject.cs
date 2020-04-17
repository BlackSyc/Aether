using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeystoneObject : MonoBehaviour
{
    [SerializeField]
    private Keystone keystone;

    public void PickUp()
    {
        if (keystone.IsFound)
        {
            Hint.Get("Keystone_AlreadyPickedUp").Activate();
            return;
        }
        Player.Instance.Inventory.PickupKeystone(keystone);
        Destroy(gameObject);
    }
}
