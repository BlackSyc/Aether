using Aether.Core.Combat.ScriptableObjects;

namespace Aether.Core.Combat
{
    public interface IModifier
    {
        ModifierType ModifierType { get; }

        float FallOffTime { get; set; }
    }
}
