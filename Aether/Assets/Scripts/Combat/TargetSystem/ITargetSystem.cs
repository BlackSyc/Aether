using Aether.Core.Combat;

namespace Aether.Combat.TargetSystem
{
    internal interface ITargetSystem : Core.Combat.ITargetSystem
    {
        new Target GetCurrentTarget();
    }
}
