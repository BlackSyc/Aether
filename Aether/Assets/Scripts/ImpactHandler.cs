using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ImpactHandler : MonoBehaviour, IImpactHandler
{
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void HandleImpact(Vector3 impact)
    {
        rigidBody.AddForce(impact);
    }

    public void HandleImpactAtPosition(Vector3 impact, Vector3 position)
    {
        rigidBody.AddForceAtPosition(impact, position);
    }


}
