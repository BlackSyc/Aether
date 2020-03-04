using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SpellSystem : MonoBehaviour
{
    [SerializeField]
    private Transform castParent;

    private SpellCast currentSpellCast;

    public SpellType Missile;

    public SpellType spellType2;

    public SpellType spellType3;

    public SpellType spellType4;

    public SpellType spellType5;

    public SpellType spellType6;

    public SpellType spellType7;

    public void CastMissile(CallbackContext context)
    {
        if (!context.performed)
            return;

        if (!Missile.HasActiveSpell)
        {
            Debug.LogWarning("No spell bound!");
            return;
        }

        currentSpellCast?.Cancel();

        currentSpellCast = Missile.Cast(castParent);
        if(currentSpellCast == null)
            return;

        currentSpellCast.CastEvents.AddListener(HandleCastEvents);
        StartCoroutine(currentSpellCast.Start());
    }

    public void CancelCast(CallbackContext context)
    {
        if (!context.performed)
            return;

        currentSpellCast?.Cancel();
    }

    public void HandleCastEvents(EventType castEvent, SpellCast spellCast)
    {
        if(castEvent == EventType.CastCancelled || castEvent == EventType.CastComplete)
        {
            currentSpellCast = null;
        }
    }

}
