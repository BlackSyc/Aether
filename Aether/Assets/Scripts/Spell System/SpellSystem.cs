using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SpellSystem : MonoBehaviour
{
    public struct Events
    {
        public static event Action<Spell> OnSpellAdded;
        public static event Action<Spell> OnSpellRemoved;
        public static event Action<SpellCast> OnCastSpell;

        public static void SpellAdded(Spell spell)
        {
            OnSpellAdded?.Invoke(spell);
        }
        public static void CastSpell(SpellCast spellCast)
        {
            OnCastSpell?.Invoke(spellCast);
        }

        internal static void SpellRemoved(Spell spell)
        {
            OnSpellRemoved?.Invoke(spell);
        }
    }
    [SerializeField]
    private Transform castParent;

    private SpellCast currentSpellCast;

    [SerializeField]
    private SpellSlot spellSlot1;

    [SerializeField]
    private SpellSlot spellSlot2;

    [SerializeField]
    private SpellSlot spellSlot3;

    [SerializeField]
    private SpellSlot spellSlot4;

    [SerializeField]
    private SpellSlot spellSlot5;

    [SerializeField]
    private SpellSlot spellSlot6;

    [SerializeField]
    private SpellSlot spellSlot7;


    public void AddSpell(Spell spell)
    {
        spell.PreferredSpellSlot.SelectSpell(spell);
        Events.SpellAdded(spell);
    }

    public void ClearAllSpells()
    {
        Spell spell1 = spellSlot1.State.Spell;
        spellSlot1.RemoveSpell();
        Events.SpellRemoved(spell1);

        // Todo: all other spellslots.
    }

    public bool HasSpells => spellSlot1.HasActiveSpell || spellSlot2.HasActiveSpell || spellSlot3.HasActiveSpell || spellSlot4.HasActiveSpell || spellSlot5.HasActiveSpell || spellSlot6.HasActiveSpell || spellSlot7.HasActiveSpell;

    public void CastMissile(CallbackContext context)
    {
        if (!context.performed)
            return;

        if (!spellSlot1.HasActiveSpell)
        {
            Debug.LogWarning("No spell bound!");
            return;
        }

        if (currentSpellCast != null)
        {
            if (currentSpellCast.Spell == spellSlot1.State.Spell)
            {
                UpdateTargetLock();
                return;
            }
            currentSpellCast.Cancel();
        }

        currentSpellCast = spellSlot1.Cast(castParent, this.GetComponent<TargetManager>());
        if (currentSpellCast == null)
            return;

        currentSpellCast.CastCancelled += ClearCurrentCast;
        currentSpellCast.CastComplete += ClearCurrentCast;
        StartCoroutine(currentSpellCast.Start());
    }

    private void ClearCurrentCast(SpellCast spellCast)
    {
        currentSpellCast.CastCancelled -= ClearCurrentCast;
        currentSpellCast.CastComplete -= ClearCurrentCast;
        this.currentSpellCast = null;
    }

    private void UpdateTargetLock()
    {
        if (!GetComponent<TargetManager>().HasLockedTarget && !GetComponent<TargetManager>().GetCurrentTarget().HasTargetTransform)
            return;

        if (GetComponent<TargetManager>().HasLockedTarget && !GetComponent<TargetManager>().GetCurrentTarget().HasTargetTransform)
            return;

        if (!GetComponent<TargetManager>().HasLockedTarget && GetComponent<TargetManager>().GetCurrentTarget().HasTargetTransform)
        {
            GetComponent<TargetManager>().LockTarget();
            return;
        }
        if (GetComponent<TargetManager>().HasLockedTarget && GetComponent<TargetManager>().GetCurrentTarget().HasTargetTransform)
        {
            GetComponent<TargetManager>().UnlockTarget();
            GetComponent<TargetManager>().LockTarget();
            return;
        }
    }

    public void MovementInterrupt(CallbackContext context)
    {
        if (context.performed || context.started)
        {
            if (currentSpellCast != null)
            {
                if (!currentSpellCast.Spell.CastWhileMoving)
                {
                    currentSpellCast.Cancel();
                }
            }
        }
    }

    public void CancelCast(CallbackContext context)
    {
        if (!context.performed)
            return;

        currentSpellCast?.Cancel();
    }

}
