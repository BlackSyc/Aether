using System;
using UnityEngine;

namespace Aether.Combat.Health
{
    internal interface IHealth : Core.Combat.IHealth
    {
        bool IsDead { get; }

        void Damage(float damage);

        Transform transform { get; }
    }
}
