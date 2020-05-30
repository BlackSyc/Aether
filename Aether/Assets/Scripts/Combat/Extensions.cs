using Aether.Core.Extensions;
using UnityEngine;

namespace Aether.Combat.Extensions
{
    internal static class Extensions
    {
        public static bool IsTarget(this GameObject gameObject, out ICombatSystem target)
        {
            bool result = gameObject.HasComponent(out target);
            return result;
        }
    }
}
