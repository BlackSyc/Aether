using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloak : MonoBehaviour
{
    [SerializeField]
    private CloakInfo cloakInfo;

    [SerializeField]
    private Spell missileSpell;

    public void Equip()
    {
        Debug.Log("Equipped cloak: " + cloakInfo.Name);
        cloakInfo.State.Equipped = true;
        transform.parent.parent.GetComponent<SpellSystem>().SpellSlot1.SelectSpell(missileSpell);

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
