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

        if(currentSpellCast != null)
        {
            if(currentSpellCast.Spell == Missile.Spell)
            {
                UpdateTargetLock();
                return;
            }
            currentSpellCast.Cancel();
        }

        

        currentSpellCast = Missile.Cast(castParent, this.GetComponent<TargetManager>());
        if (currentSpellCast == null)
            return;

        currentSpellCast.CastCancelled += x => this.currentSpellCast = null;
        currentSpellCast.CastComplete += x => this.currentSpellCast = null;
        StartCoroutine(currentSpellCast.Start());
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
            if(currentSpellCast != null)
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
