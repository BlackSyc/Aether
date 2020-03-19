using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloak : MonoBehaviour
{
    [SerializeField]
    private CloakInfo cloakInfo;

    [SerializeField]
    private Spell arcaneMissile;

    [SerializeField]
    private Spell missileSpell;

    public void Equip()
    {
        cloakInfo.Equip();
        AetherEvents.GameEvents.SpellSystemEvents.GrantNewSpell(missileSpell);

        // add spells
        // perform spawning animation
    }

    public void Unequip()
    {
        AetherEvents.GameEvents.SpellSystemEvents.RemoveSpell(missileSpell);
        AetherEvents.GameEvents.SpellSystemEvents.GrantNewSpell(arcaneMissile);
        cloakInfo.UnEquip();
        // remove spells
        // perform spawning animation
    }
}
