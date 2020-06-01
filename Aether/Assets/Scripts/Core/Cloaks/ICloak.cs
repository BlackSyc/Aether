using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Core.Cloaks
{
    public interface ICloak
    {
        string Name { get; }

        Aspect Aspect { get; }

        Color Colour { get; }

        string Keywords { get; }

        string Description { get; }

        ISpell[] Spells { get; }


        GameObject CloakPrefab { get; }
    }
}
