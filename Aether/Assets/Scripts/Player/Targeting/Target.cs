using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target
{
    public Vector3 Position { get {
            return HasTargetTransform ? targetTransform.position : targetPosition;
        }}

    public bool HasTargetTransform
    {
        get
        {
            return targetTransform != null;
        }
    }

    private Transform targetTransform;

    private Vector3 targetPosition;

    public Target(Vector3 position)
    {
        targetTransform = null;
        this.targetPosition = position;
    }

    public Target(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }
}
