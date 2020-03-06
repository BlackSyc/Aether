using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloak : MonoBehaviour
{
    [SerializeField]
    private CloakInfo cloakInfo;

    public void Equip()
    {
        Debug.Log("Equipped cloak: " + cloakInfo.Name);
        cloakInfo.State.Equipped = true;
        // add spells
        // perform spawning animation
    }

    public void Unequip()
    {
        Debug.Log("Unequipped cloak: " + cloakInfo.Name);
        cloakInfo.State.Equipped = false;
        // remove spells
        // perform spawning animation
    }
}
