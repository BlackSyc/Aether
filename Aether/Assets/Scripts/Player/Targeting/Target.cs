using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target
{
    public GameObject TargetObject { get; private set; }
    public Vector3 Position { get; private set; }
    public bool HasTargetObject { get; private set; } = false;

    public Target(Vector3 position)
    {
        TargetObject = null;
        Position = position;
        HasTargetObject = false;
    }

    public Target(Vector3 position, GameObject targetObject)
    {
        TargetObject = targetObject;
        Position = position;
        HasTargetObject = true;
    }
}
