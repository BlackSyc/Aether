﻿using UnityEngine;

namespace Aether.Core.Combat
{
    public interface ITargetSystem
    {
        ICombatSystem GetCurrentTarget(LayerMask layerMask);
    }
}
