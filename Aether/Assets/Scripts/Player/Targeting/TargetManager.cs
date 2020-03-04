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
    private LayerMask layers;

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

        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxRange, layers))
        {
            return new Target(hit.transform);
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
