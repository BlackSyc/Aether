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

        if (!spellSlot1.HasActiveSpell)
        {
            Debug.LogWarning("No spell bound!");
            return;
        }

        currentSpellCast?.Cancel();

        currentSpellCast = spellSlot1.Cast(transform);
        if(currentSpellCast == null)
            return;

        currentSpellCast.CastEvents.AddListener(HandleCastEvents);
        StartCoroutine(currentSpellCast.Start());
    }

    public void HandleCastEvents(EventType castEvent, SpellCast spellCast)
    {
        if(castEvent == EventType.CastCancelled || castEvent == EventType.CastComplete)
        {
            currentSpellCast = null;
        }
    }

}
