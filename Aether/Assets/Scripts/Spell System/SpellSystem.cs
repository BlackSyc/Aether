using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SpellSystem : MonoBehaviour
{
    [SerializeField]
    private Transform castParent;

    private SpellCast currentSpellCast;

    [SerializeField]
    private SpellSlot spellSlot1;

    public SpellSlot SpellSlot1
    {
        get
        {
            return spellSlot1;
        }
    }

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

    private void Start()
    {
        spellSlot1.Initialize();
    }

    public void CastMissile(CallbackContext context)
    {
        if (!context.performed)
            return;

        if (!SpellSlot1.HasActiveSpell)
        {
            Debug.LogWarning("No spell bound!");
            return;
        }

        if (currentSpellCast != null)
        {
            if (currentSpellCast.Spell == SpellSlot1.State.Spell)
            {
                UpdateTargetLock();
                return;
            }
            currentSpellCast.Cancel();
        }

        currentSpellCast = SpellSlot1.Cast(castParent, this.GetComponent<TargetManager>());
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
