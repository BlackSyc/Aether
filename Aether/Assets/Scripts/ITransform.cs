using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// While technically not an interface, this class serves the purpose as an interface in only exposing certain readonly elements of a transform.
/// </summary>
public class ITransform : Object
{

    private Transform transform;

    public ITransform(Transform transform)
    {
        this.transform = transform;
    }

    public Vector3 Position => transform.position;

    public Vector3 LocalPosition => transform.localPosition;

    public Quaternion LocalRotation => transform.localRotation;

    public Quaternion Rotation => transform.rotation;

    public Vector3 LocalScale => transform.localScale;


}
