using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeystoneObject : MonoBehaviour
{
    [SerializeField]
    private Keystone keystone;

    public void PickUp()
    {
        Player.Instance.Inventory.PickupKeystone(keystone);
        Destroy(gameObject);
    }
}
