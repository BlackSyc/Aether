using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetManager : MonoBehaviour
{

    public bool HasLockedTarget => lockedTarget != null;

    public Target Target => lockedTarget != null ? lockedTarget : GetCurrentTarget();

    [SerializeField]
    private SpellSystem spellSystem;

    private Target lockedTarget;

    private LayerMask layerMask;

    public LayerMask LayerMask => layerMask;

    private void Start()
    {
        spellSystem.OnActiveSpellChanged += _ => UpdateLayerMask();
        UpdateLayerMask();
    }

    private void OnDestroy()
    {
        spellSystem.OnActiveSpellChanged -= _ => UpdateLayerMask();
    }

    public abstract Target GetCurrentTarget();

    private void UpdateLayerMask()
    {
        layerMask = Player.Instance.SpellSystem.GetCombinedLayerMask();
    }

    public void LockTarget()
    {
        lockedTarget = GetCurrentTarget();
    }

    public void UnlockTarget()
    {
        lockedTarget = null;
    }
}
