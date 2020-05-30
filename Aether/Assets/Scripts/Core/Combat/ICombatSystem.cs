using UnityEngine;

namespace Aether.Core.Combat
{
    public interface ICombatSystem
    {
        T Get<T>();

        bool Has<T>(out T t);

        string Name { get; }

        ITransform Transform { get; }
    }
}
