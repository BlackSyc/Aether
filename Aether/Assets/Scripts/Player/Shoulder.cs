using Aether.Combat;
using Aether.Combat.SpellSystem;
using ScriptableObjects;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    public CombatSystem CombatSystem;

    private Cloak equippedCloak = null;

    public Cloak EquippedCloak => equippedCloak;

    [SerializeField]
    private Spell defaultSpell;

    public void EnableCloakPhysics()
    {
        if (transform.GetChild(0) == null)
            return;

        transform.GetChild(0).GetComponent<Cloth>().enabled = true;
    }

    public void DisableCloakPhysics()
    {
        if (transform.GetChild(0) == null)
            return;

        transform.GetChild(0).GetComponent<Cloth>().enabled = false;
    }

    public void EquipCloak(Cloak cloak)
    {
        if(equippedCloak != null)
            UnequipCloak();

        equippedCloak = cloak;
        cloak.Equip(transform);
    }

    public void UnequipCloak()
    {
        var cloak = equippedCloak;
        equippedCloak = null;
        cloak?.Unequip();
        CombatSystem.Get<ISpellSystem>().AddSpell(0, defaultSpell);
    }
}
