using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelController
{
    Transform GetEntryPoint();

    void Enable();

    void Disable();
}
