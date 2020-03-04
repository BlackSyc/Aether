using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target
{
    public Vector3 Position { get {
            return HasTargetTransform ? TargetTransform.position : targetPosition;
        }}

    public bool HasTargetTransform
    {
        get
        {
            return TargetTransform != null;
        }
    }

    public Transform TargetTransform { get;  private set; }

    private Vector3 targetPosition;

    public Target(Vector3 position)
    {
        TargetTransform = null;
        this.targetPosition = position;
    }

    public Target(Transform targetTransform)
    {
        this.TargetTransform = targetTransform;
    }
}
