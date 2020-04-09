using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SpellSystem : MonoBehaviour
{
    public event Action<SpellLibrary> OnActiveSpellChanged;

    public void ActiveSpellChanged(SpellLibrary spellLibrary)
    {
        OnActiveSpellChanged?.Invoke(spellLibrary);
    }

    public event Action<SpellCast> OnSpellIsCast;

    public void SpellIsCast(SpellCast spellCast)
    {
        OnSpellIsCast?.Invoke(spellCast);
    }

    [SerializeField]
    private Transform castParent;

    private SpellCast currentSpellCast;

    public bool IsCasting => currentSpellCast != null;

    [SerializeField]
    private SpellLibrary[] spellLibraries;

    public SpellLibrary[] SpellLibraries => spellLibraries;

    private bool castOnSelf = false;


    private void Start()
    {
        spellLibraries.ForEach(x => x.OnActiveSpellChanged += _ => ActiveSpellChanged(x));
    }

    private void OnDestroy()
    {
        spellLibraries.ForEach(x => x.OnActiveSpellChanged -= _ => ActiveSpellChanged(x));
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

    public void ToggleCastOnSelf(CallbackContext context)
    {
        castOnSelf = !context.canceled;
        Debug.Log($"cast on self = {castOnSelf}");
    }

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

    public SpellCast CastSpell(int index)
    {
        if (currentSpellCast != null)
        {
            if (currentSpellCast.Spell == spellLibraries[index].ActiveSpell)
            {
                if (castOnSelf && !currentSpellCast.OnSelf)
                {
                    Debug.Log("Cast was on target, but will now be on self!");
                    currentSpellCast.OnSelf = true;
                    GetComponent<TargetManager>().UnlockTarget();
                }
                if(!castOnSelf && currentSpellCast.OnSelf)
                {
                    Debug.Log("Cast was on self, but will now be on target!");
                    currentSpellCast.OnSelf = false;
                    UpdateTargetLock(currentSpellCast.Spell.layerMask);
                }

                return currentSpellCast;
            }
            currentSpellCast.Cancel();
        }

        if (!spellLibraries[index].Cast(out currentSpellCast, castParent, gameObject, GetComponent<TargetManager>(), castOnSelf))
            return null;

        currentSpellCast.CastCancelled += ClearCurrentCast;
        currentSpellCast.CastComplete += ClearCurrentCast;
        StartCoroutine(currentSpellCast.Start());
        SpellIsCast(currentSpellCast);
        return currentSpellCast;
    }

    private void ClearCurrentCast(SpellCast spellCast)
    {
        currentSpellCast.CastCancelled -= ClearCurrentCast;
        currentSpellCast.CastComplete -= ClearCurrentCast;
        this.currentSpellCast = null;
    }

    private void UpdateTargetLock(LayerMask layerMask)
    {
        PlayerTargetManager targetManager = GetComponent<PlayerTargetManager>();

        if (targetManager.GetCurrentTarget().HasTargetTransform && layerMask.Contains(targetManager.GetCurrentTarget().TargetTransform.gameObject))
        {
            if (targetManager.HasLockedTarget)
                targetManager.UnlockTarget();

            targetManager.LockCurrentTarget();
        }
    }

    public void CancelCast(CallbackContext context)
    {
        if (!context.performed)
            return;

        currentSpellCast?.Cancel();
    }

}
