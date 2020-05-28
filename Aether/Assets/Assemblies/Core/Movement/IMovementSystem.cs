using UnityEngine;

namespace Aether.Core.Movement
{
    public interface IMovementSystem
    {
        float MovementSpeed { get; set; }
        bool IsActive { get; set; }
    }
}
