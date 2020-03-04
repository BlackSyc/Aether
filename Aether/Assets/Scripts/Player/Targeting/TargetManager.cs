using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    [SerializeField] 
    private Transform camera;

    [SerializeField] 
    private float maxRange = 100f;

    [SerializeField]
    private LayerMask targetLayer;

    [SerializeField]
    private LayerMask obstructionLayer;

    public bool HasLockedTarget { get
        {
            return lockedTarget != null;
        }
    }

    private Target lockedTarget;



    public Target GetCurrentTarget()
    {
        if (lockedTarget != null)
            return lockedTarget;

        RaycastHit obstructionHit;
        bool obstructionHitFound = Physics.Raycast(camera.position, camera.forward, out obstructionHit, maxRange, obstructionLayer);

        RaycastHit targetHit;
        bool targetHitFound = Physics.Raycast(camera.position, camera.forward, out targetHit, maxRange, targetLayer);

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

    public void LockTarget(Target target)
    {
        lockedTarget = target;
    }

    public void UnlockTarget()
    {
        lockedTarget = null;
    }
}
