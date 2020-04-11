using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelController
{
    Transform GetEntryPoint();

    LevelExit GetLevelExit();

    void Enable();

    void Disable();
}
