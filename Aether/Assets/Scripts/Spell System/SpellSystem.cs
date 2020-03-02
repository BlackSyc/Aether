using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SpellSystem : MonoBehaviour
{
    private SpellCast currentSpellCast;

    public SpellSlot spellSlot1;

    public SpellSlot spellSlot2;

    public SpellSlot spellSlot3;

    public SpellSlot spellSlot4;

    public SpellSlot spellSlot5;

    public void CastSpell1(CallbackContext context)
    {
        if (!context.performed)
            return;

        if (!spellSlot1.hasActiveSpell())
        {
            Debug.LogWarning("No spell bound!");
            return;
        }
        currentSpellCast = new SpellCast(spellSlot1?.spell, transform);
        StartCoroutine(currentSpellCast.Start());
    }

}
