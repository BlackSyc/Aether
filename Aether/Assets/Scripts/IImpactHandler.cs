using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImpactHandler
{
    void HandleImpact(Vector3 impact);

    void HandleImpactAtPosition(Vector3 impact, Vector3 position);
}
