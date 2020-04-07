using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    private Cloak equippedCloak;

    private void Start()
    {
        equippedCloak = Player.Instance.Shoulder.EquippedCloak;
        Cloak.Events.OnCloakUnequipped += CloakUnequipped;
    }

    private void CloakUnequipped(Cloak cloak)
    {
        if (cloak == equippedCloak)
        {
            Player.Instance.Companion = null;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Cloak.Events.OnCloakUnequipped -= CloakUnequipped;
    }
}
