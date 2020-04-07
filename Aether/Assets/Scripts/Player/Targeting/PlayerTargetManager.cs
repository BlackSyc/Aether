using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetManager : TargetManager
{

    [SerializeField] 
    private Transform camera;

    [SerializeField] 
    private float maxRange = 100f;




    public override Target GetCurrentTarget()
    {
        RaycastHit obstructionHit;
        bool obstructionHitFound = Physics.Raycast(camera.position, camera.forward, out obstructionHit, maxRange, Layers.ObstructionLayer);

        RaycastHit targetHit;
        bool targetHitFound = Physics.Raycast(camera.position, camera.forward, out targetHit, maxRange, LayerMask);

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
}
