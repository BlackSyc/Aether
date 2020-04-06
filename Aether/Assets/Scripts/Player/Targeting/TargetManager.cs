using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    [SerializeField] 
    private Transform camera;

    [SerializeField] 
    private float maxRange = 100f;

    private LayerMask layerMask;

    private void Start()
    {
        SpellSystem.Events.OnActiveSpellChanged += _ => UpdateLayerMask();
    }

    private void UpdateLayerMask()
    {
        layerMask = Player.Instance.SpellSystem.GetCombinedLayerMask();
    }

    private void OnDestroy()
    {
        SpellSystem.Events.OnActiveSpellChanged -= _ => UpdateLayerMask();
    }

    public bool HasLockedTarget { get
        {
            return lockedTarget != null;
        }
    }

    public Target Target
    {
        get
        {
            return lockedTarget != null ? lockedTarget : GetCurrentTarget();
        }
    }

    private Target lockedTarget;

    public Target GetCurrentTarget()
    {
        RaycastHit obstructionHit;
        bool obstructionHitFound = Physics.Raycast(camera.position, camera.forward, out obstructionHit, maxRange, Layers.ObstructionLayer);

        RaycastHit targetHit;
        bool targetHitFound = Physics.Raycast(camera.position, camera.forward, out targetHit, maxRange, layerMask);

        if (targetHitFound)
        {
            if(obstructionHitFound)
            {
                if (Vector3.Distance(camera.position, targetHit.transform.position) > Vector3.Distance(camera.position, obstructionHit.point))
                {
                    return new Target(obstructionHit.point);
                }
            }
            return new Target(targetHit.transform);
        }
        else if(obstructionHitFound)
        {
            return new Target(obstructionHit.point);
        }


        Vector3 emptyTargetPosition = camera.position + camera.forward * maxRange;

        return new Target(emptyTargetPosition);
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
