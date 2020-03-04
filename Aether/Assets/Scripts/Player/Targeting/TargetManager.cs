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



    public Target GetCurrentTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxRange, layers))
        {
            return new Target(hit.point, hit.transform.gameObject);
        }

        Vector3 emptyTargetPosition = camera.position + camera.forward * maxRange;

        return new Target(emptyTargetPosition);
    }
}
