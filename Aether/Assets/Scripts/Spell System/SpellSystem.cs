using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SpellSystem : MonoBehaviour
{
    public struct Events
    {
        public static event Action<SpellCast> OnCastSpell;

        public static event Action<SpellLibrary> OnActiveSpellChanged;

        public static void CastSpell(SpellCast spellCast)
        {
            OnCastSpell?.Invoke(spellCast);
        }

        public static void ActiveSpellChanged(SpellLibrary spellLibrary)
        {
            OnActiveSpellChanged?.Invoke(spellLibrary);
        }
    }
    [SerializeField]
    private Transform castParent;

    private SpellCast currentSpellCast;

    [SerializeField]
    private SpellLibrary[] spellLibraries;

    public SpellLibrary[] SpellLibraries => spellLibraries;


    private void Start()
    {
        spellLibraries.ForEach(x => x.OnActiveSpellChanged += _ => Events.ActiveSpellChanged(x));
    }

    private void OnDestroy()
    {
        spellLibraries.ForEach(x => x.OnActiveSpellChanged -= _ => Events.ActiveSpellChanged(x));
    }

    public LayerMask GetCombinedLayerMask()
    {
        LayerMask layerMask = new LayerMask();

        spellLibraries
            .Where(x => x.HasActiveSpell)
            .Select(x => x.ActiveSpell.layerMask)
            .ForEach(x => layerMask = layerMask | x);

        return layerMask;
    }

    public bool HasActiveSpells => spellLibraries.Any(x => x.HasActiveSpell);

    public void CastSpell1(CallbackContext context)
    {
        if (!context.performed)
            return;

        CastSpell(0);
    }

    public void CastSpell2(CallbackContext context)
    {
        if (!context.performed)
            return;

        CastSpell(1);
    }

    public void CastSpell3(CallbackContext context)
    {
        if (!context.performed)
            return;

        CastSpell(2);
    }

    public void CastSpell4(CallbackContext context)
    {
        if (!context.performed)
            return;

        CastSpell(3);
    }

    public void CastSpell5(CallbackContext context)
    {
        if (!context.performed)
            return;

        CastSpell(4);
    }

    public void CastSpell6(CallbackContext context)
    {
        if (!context.performed)
            return;

        CastSpell(5);
    }

    public void CastSpell7(CallbackContext context)
    {
        if (!context.performed)
            return;

        CastSpell(6);
    }

    public void CastSpell(int index)
    {
        if (currentSpellCast != null)
        {
            if (currentSpellCast.Spell == spellLibraries[index].ActiveSpell)
            {
                UpdateTargetLock(currentSpellCast.Spell.layerMask);
                return;
            }
            currentSpellCast.Cancel();
        }

        if (!spellLibraries[index].Cast(out currentSpellCast, castParent, GetComponent<TargetManager>()))
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

    private void UpdateTargetLock(LayerMask layerMask)
    {
        TargetManager targetManager = GetComponent<TargetManager>();

        if (targetManager.GetCurrentTarget().HasTargetTransform && layerMask.Contains(targetManager.GetCurrentTarget().TargetTransform.gameObject))
        {
            if (targetManager.HasLockedTarget)
                targetManager.UnlockTarget();

            targetManager.LockTarget();
        }
    }

    public void CancelCast(CallbackContext context)
    {
        if (!context.performed)
            return;

        currentSpellCast?.Cancel();
    }

}
